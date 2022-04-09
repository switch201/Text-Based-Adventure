using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Engine
{
    public class RoomController
    {
        public  Room currentRoom;

        public RoomItemController itemController;

        public void AttemptToChangeRooms(string direction)
        {
            if (currentRoom.getExits().ContainsKey(direction))
            {
                currentRoom = currentRoom.Exit(direction);
            }
        }

        public void InspectRoom()
        {
            currentRoom.Inspect();
        }
    }
}
