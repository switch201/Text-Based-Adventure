using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Levels;

namespace Text_Based_Adventure.Engine.Games
{
    public class Game
    {
        public List<Level> Levels;

        public Game() {
            Levels = new List<Level>() { };
        }

        public Game(Level level)
        {
            Levels = new List<Level>() { };
            Levels.Add(level);
        }
    }
}
