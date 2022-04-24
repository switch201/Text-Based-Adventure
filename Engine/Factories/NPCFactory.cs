using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.Engine.Factories
{
    class NPCFactory
    {
        public static NPC MakeNPC(string npcName)
        {
            return JsonConvert.DeserializeObject<NPC>(Util.Readfile($"Content/TestLevel/JsonContent/GameObjects/NPCs/{npcName}Text.json"));
        }
    }
}
