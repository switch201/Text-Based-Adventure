﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Doors;
using Text_Based_Adventure.Engine.Rooms;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Rooms
{
    public abstract class Room : GameObject
    {

        protected new RoomDTO dto;

        protected Dictionary<string, Room> Exits;

        public Dictionary<string, Door> Doors; 

        public List<GameObject> Items;

        public Room()
        {
            Exits = new Dictionary<string, Room>() { };
            dto = JsonConvert.DeserializeObject<RoomDTO>(Readfile("Engine/GameObjects/Rooms/RoomText.json"));
        }

        public Room Enter() {
            Util.wl(dto.EnterText);
            return this;
        }

        public Room Exit(Room r) {
            Util.wl(dto.ExitText);
            return r.Enter();
        }

        public Room Exit(string direction)
        {
            return Exit(getExit(direction));
        }

        public Dictionary<string, Room> getExits()
        {
            return this.Exits;
        }

        public void setExits(Dictionary<string, Room> exits)
        {
            this.Exits = exits;
        }

        public Room getExit(string direction)
        {
            return Exits.GetValueOrDefault(direction);
        }

        public void setExit(string direction, Room room)
        {
            Exits.Add(direction, room);
        }
    }
}
