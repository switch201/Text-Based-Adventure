using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Factories;
using Text_Based_Adventure.Engine.GameClasses;
using Text_Based_Adventure.Engine.Levels;

namespace Text_Based_Adventure.Engine.Games
{

    //TODO right now no reason to have a game can just have level as this just copies level data
    public class Game
    {
        public List<Level> Levels;

        public List<GameClass> AvailableGameClasses;

        public Game(Level level)
        {
            AvailableGameClasses = new List<GameClass>() { };
            AvailableGameClasses.AddRange(level.GameClasses);
            Levels = new List<Level>() { };
            Levels.Add(level);
        }
    }
}
