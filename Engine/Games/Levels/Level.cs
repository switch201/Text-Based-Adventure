using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Rooms;

namespace Text_Based_Adventure.Engine.Levels
{
    internal class Level
    {
        public List<Room> Rooms;

        //public List<GameClass> GameClasses;

        public Level()
        {
            Rooms = new List<Room>();
            //GameClasses = new List<GameClass>();
        }
    }
}
