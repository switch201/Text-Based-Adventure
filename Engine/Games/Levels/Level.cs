using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Rooms;

namespace Text_Based_Adventure.Engine.Levels
{
    internal class Level
    {
        public List<Room> Rooms;

        public string WorldBackStory;

        public static string ChatGPTSystemMsssage = "This is a TextBased Adventure RPG Game. You will be used to generate dialog for NPCs within the game. " +
            "You will keep track of NPCs Based on their Name. When the Player talks to a given NPC." +
            "The end of the of the input will always denote the NPC the player is talking to, and you should respond in charcter for that NPC" +
            "You will be provided with a \"WorldBackStory\" To describe the world that the the NPC you player are in. You will also Have the following information " +
            "About each NPC you play: \"BackStory\", \"Knowledge\", \"Motives\", and \"Fears\". \"BackStory\" represents the given NPCs History. \"Knowledge\" represents " +
            "What the NPC knows about the world around him. \"Motives\" and \"Fears\" are self explanitory. The game world is made up of many different areas there are often called rooms. " +
            "Rooms contain Contents, and you will be fed information on what these items are in JSON format. When you respond as characters you should respond in JSON format." +
            "he JSON should have to properties: \"Message\", which will be the dialog the character would respond with, and \"Action\". \"Action\" can be one of 3 values: " +
            "1) \"Trade\": You should set the \"Action\" property to \"Trade\" when ever you think the player is trying to initiate trade with the NPC. 2) \"Combat\": " +
            "You should set the \"Action\" property to \"Comabt\" if you think that the NPC in question would initiate combat as a result of the player prompt. 3) \"Default\" " +
            "You should set the \"Action\" property to \"Default\" in all other cases. Again you should always respond in JSON format as with this example: {\"Message\" : \"Hellp My Name is Jesica\"," +
            "\"Action\" : \"Default\"";

        //public List<GameClass> GameClasses;

        public Level()
        {
            Rooms = new List<Room>();
        }
    }
}
