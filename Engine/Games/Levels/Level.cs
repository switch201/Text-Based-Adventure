using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Engine.Levels
{
    public abstract class Level
    {
        public List<Room> Rooms;
        public Room StartingRoom;
    }
}
