using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Content.TestLevel.Rooms;
using Text_Based_Adventure.Engine.Levels;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Content.TestLevel
{
    class TestLevel : Level
    {
        public TestLevel()
        {
            Room room1 = new TreasureRoom();
            Room room2 = new Prison();

            room1.setExit("west", room2);
            room2.setExit("west", room1);
        }
    }
}
