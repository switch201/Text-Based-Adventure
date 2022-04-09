﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Doors;
using Text_Based_Adventure.Engine.Rooms;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Content
{
    class TreasureRoom : Room
    {
        public TreasureRoom()
        {
            dto = JsonConvert.DeserializeObject<RoomDTO>(Readfile("Content/TestLevel/JsonContent/GameObjects/Rooms/TreasureRoomText.json"));
        }
    }
}