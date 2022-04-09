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

        public ItemController itemController;

        public void AttemptToChangeRooms(string direction)
        {
            if (currentRoom.getExits().ContainsKey(direction))
            {
                currentRoom = currentRoom.Exit(direction);
            }
        }

        //TODO Make this skill based and have different exits be different levels of hidden
        public void SearchForExits()
        {
            Dictionary<string, Room> exits = currentRoom.getExits();
            int totalExits = exits.Count;
            foreach(string exit in exits.Keys)
            {
                Util.wl($"You see an exit to the {exit}");
            }
        }

        public void SearchForItems()
        {
            //Dictionary<string, Room> exits = currentRoom.getItems();
            //int totalExits = exits.Count;
            //foreach (string exit in exits.Keys)
            //{
            //    Util.wl($"You see an exit to the {exit}");
            //}
        }


        //TODO Add skill check to change text and maybe give different clues
        // maybe instead just have inspect auto call all search for commands?
        public void InspectRoom()
        {
            currentRoom.Inspect();
        }
    }
}
