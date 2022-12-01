using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Rooms;

namespace Text_Based_Adventure.Engine.Controllers
{
    // Controlls which room the player is in by holding the current Room
    internal class RoomController
    {
        public Room CurrentRoom;

        public void SetCurrentRoom(Room currentRoom) { 
            CurrentRoom = currentRoom;
        }
    }
}
