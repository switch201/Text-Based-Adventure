using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Doors;
using Text_Based_Adventure.Engine.Rooms;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Rooms
{
    public class Room : GameObject
    {

        protected new RoomDTO dto;

        public Dictionary<string, Room> Exits;

        public Dictionary<string, Door> Doors;

        public List<GameObject> Items;

        public Room()
        {
            dto = JsonConvert.DeserializeObject<RoomDTO>(Readfile("Content/JsonContent/GameObjects/Rooms/RoomText.json"));
        }

        public void Enter() {

            Util.wl(dto.EnterText);
        }

        public void Exit(Room r) {
            Util.wl(dto.ExitText);
            r.Enter();
        }
    }
}
