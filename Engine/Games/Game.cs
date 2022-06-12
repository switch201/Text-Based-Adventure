using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Factories;
using Text_Based_Adventure.Engine.GameClasses;
using Text_Based_Adventure.Engine.Levels;

namespace Text_Based_Adventure.Engine.Games
{
    public class Game
    {
        public List<Level> Levels;

        public List<GameClass> AvailableGameClasses;

        public Game() {
            Levels = new List<Level>() { };
            AvailableGameClasses = new List<GameClass>() { };
            AvailableGameClasses.Add(GameClassFactory.MakeBarbarianClass());
        }

        public Game(Level level)
        {
            AvailableGameClasses = new List<GameClass>() { };
            AvailableGameClasses.Add(GameClassFactory.MakeBarbarianClass());
            Levels = new List<Level>() { };
            Levels.Add(level);
        }
    }
}
