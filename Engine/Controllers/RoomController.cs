using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Rooms;
using System.Linq;

namespace Text_Based_Adventure.Engine
{
    public class RoomController
    {
        public  Room currentRoom;


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


        //TODO skill check
        public void SearchForItems()
        {
            
            Dictionary<string, Item> items = currentRoom.getItems();

            if (items.Count == 0)
            {
                Util.wl("You don't see any items");
            }

            int totalItems = items.Count;
            foreach (var (name, item) in items)
            {
                if (item.HasDiscoverText())
                {
                    item.Discover();
                }
                Util.wl($"You see a {name}");
            }
        }

        public void InspectItem(string name)
        {
            Item item = currentRoom.Items.GetValueOrDefault(name);
            if(item == null)
            {
                Util.wl("You can't inspect that.");
            }
            else
            {
                item.Inspect();
                item.getQuality();
            }
            
        }


        //TODO Add skill check to change text and maybe give different clues
        // maybe instead just have inspect auto call all search for commands?
        public void InspectRoom()
        {
            currentRoom.Inspect();
        }
    }
}
