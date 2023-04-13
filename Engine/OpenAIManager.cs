using OpenAI_API;
using OpenAI_API.Chat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Text_Based_Adventure.Engine.GameObjects.Actors;
using Text_Based_Adventure.Engine.Levels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Text_Based_Adventure.Engine.GameObjects.Rooms;

namespace Text_Based_Adventure.Engine
{
    internal class OpenAIManager
    {
        OpenAIAPI api;

        Conversation chat;

        public NPC currentNPC;

        public OpenAIManager()
        {
            api = new OpenAIAPI("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"); // uses default, env, or config file
        }

        public void LoadGameData(Level level)
        {
            chat = api.Chat.CreateConversation();
            LoadLevelData(level);
        }

        private void LoadLevelData(Level level)
        {
            chat.AppendSystemMessage(Level.ChatGPTSystemMsssage);
            chat.AppendSystemMessage("Here is infomration about the Game World");
            chat.AppendSystemMessage(level.WorldBackStory);
            foreach(var room in level.Rooms)
            {
                chat.AppendSystemMessage("Here is some information about a Room or Area");
                chat.AppendSystemMessage(room.Description);
                chat.AppendSystemMessage("Here is some information about the NPCs in this room. Keep track of what room each NPC is in and is not in");
                foreach (var npc in room.GetNPCs())
                {
                    chat.AppendSystemMessage(JsonConvert.SerializeObject(npc));
                    chat.AppendSystemMessage($"Here is some information about the items ${npc.Name} is carrying");
                    foreach(var item in npc.Inventory)
                    {
                        chat.AppendSystemMessage(JsonConvert.SerializeObject(item));
                    }
                }
            }
            
            //var levelJson = JsonConvert.SerializeObject(level, Formatting.None,
            //            new JsonSerializerSettings()
            //            {
            //                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //            });
            //chat.AppendSystemMessage(levelJson);
        }
        //private void LoadNPCData(List<NPC> NPCs)
        //{
        //    chat.AppendSystemMessage("Here is information about all NPCs, Where they are in the world, and what they are carrying is included.");
        //    foreach (NPC npc in NPCs)
        //    {
        //        chat.AppendSystemMessage(JsonConvert.SerializeObject(npc));
        //        chat.AppendSystemMessage("Here is information about all NPCs, Where they are in the world, and what they are carrying is included.");
        //    }
        //}

        public Task<string> TalkToNPC(string playerInput)
        {
            chat.AppendUserInput($"Player Says to NPC: \"{currentNPC.Name}\": {playerInput}");
            return chat.GetResponseFromChatbot();
        }
    }
}
