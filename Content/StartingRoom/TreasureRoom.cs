using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Doors;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Content
{
    class TreasureRoom : Room
    {
        public Dictionary<string, Room> Exits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<string, Door> Doors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<GameObject> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Enter()
        {
            return TreasureRoom
        }
    }
}
