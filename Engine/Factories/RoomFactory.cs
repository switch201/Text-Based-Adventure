using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Content;
using Text_Based_Adventure.Content.TestLevel.Rooms;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Engine.Factories
{
    class RoomFactory : Factory
    {
        public static Room MakeRoom(string roomName)
        {
            return JsonConvert.DeserializeObject<Room>(Util.Readfile($"{basePath}/GameObjects/Rooms/{roomName}Text.json"));
        }

        public static TreasureRoom MakeTresureRoom(string roomName)
        {
            return JsonConvert.DeserializeObject<TreasureRoom>(Util.Readfile($"{basePath}/GameObjects/Rooms/{roomName}Text.json"));
        }

        public static Prison MakePrison(string roomName)
        {
            return JsonConvert.DeserializeObject<Prison>(Util.Readfile($"{basePath}/GameObjects/Rooms/{roomName}Text.json"));
        }
    }
}
