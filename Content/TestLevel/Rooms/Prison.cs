using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Factories;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Content.TestLevel.Rooms
{
    class Prison : Room
    {
        public Prison(string roomName) : base(roomName)
        {
            //this.addNPC(NPCFactory.MakeNPC("fred"));
        }
    }
}
