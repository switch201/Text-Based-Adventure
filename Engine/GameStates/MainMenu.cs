using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameStates;

namespace Text_Based_Adventure
{
    class MainMenu : GameState
    {

        static List<string> keyWords = new List<string>() { "new", "load", "quit"};
        public static void Start()
        {
            Util.wl("Type \"new\" to start a new game or \"load\" to load a save.");

            string entry = Util.rl();
            while (!keyWords.Contains(entry))
            {
                Util.wl("Type \"new\" to start a new game or \"load\" to load a save.");
            }

            HandleEntry(entry);

        }

        private static void HandleEntry(string entry)
        {
            switch(entry)
            {
                case "new":
                    break;
                case "load":
                    Util.wl("Sorry Thats not working yet good bye");
                    break;
            }
        }
    }
}
