using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Factories;
using Text_Based_Adventure.Engine.GameObjects.Rooms;
using Text_Based_Adventure.Engine.Levels;

namespace Text_Based_Adventure.Engine.Games
{

    //TODO right now no reason to have a game can just have level as this just copies level data
    internal class Game
    {
        public List<Level> Levels;

        //public List<GameClass> AvailableGameClasses;

        public Game(Level level)
        {
            //AvailableGameClasses = new List<GameClass>() { };
            //AvailableGameClasses.AddRange(level.GameClasses);
            Levels = new List<Level>() { };
            Levels.Add(level);
        }
    }
}
