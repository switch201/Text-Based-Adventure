using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.GameObjects.Rooms
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Forward,
        Back,
        North,
        South,
        East,
        West,
        Northeast,
        Southeast,
        Southwest,
        Northwest,
    }
    internal class Exit : GameObject
    {
        public Direction Direction;
        public Room EnteringRoom;
    }
}
