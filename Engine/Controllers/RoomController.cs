using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Rooms;
using System.Linq;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Containers;

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
            else
            {
                Util.wl("You can't go that way. type 'search exits' to see exits from this room.");
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
        public void SearchForCreatures()
        {
            List<NPC> npcs = currentRoom.getNPCs();

            if (npcs.Count == 0)
            {
                Util.wl("You don't see any people or creatures");
            }
            foreach (var npc in npcs)
            {
                Util.wl($"You see a {npc.DescriptionText}");
            }
        }


        
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

        public void InspectSomething(string name, int checkResult)
        {
            //check for items
            Item item = currentRoom.Items.GetValueOrDefault(name);
            if(item != null)
            {
                InspectItem(item, checkResult);
                return;
            }
            //check for creatures
            NPC npc = currentRoom.NPCs.Find(npc => npc.Name == name);
            if(npc != null)
            {
                InspectNpc(npc, checkResult);
                return;
            }
            else
            {
                Util.wl("You can't inspect that.");
            }
        }

        public void InspectNpc(NPC npc, int checkResult)
        {
            npc.Inspect(checkResult);
        }

        public void InspectItem(Item item, int checkResult)
        {
            item.Inspect();
            item.getQuality();
        }

        public void TalkToNpc(string nameOrIdentifier)
        {
            NPC target = this.currentRoom.GetNPC(nameOrIdentifier);

            if (target != null)
            {
                target.SaySmallTalk();
            }
            else
            {
                Util.wl("Talk to who now?");
            }
        }

        public void RemoveNPC(string npcName)
        {
            this.RemoveNPC(currentRoom.GetNPC(npcName));
        }

        //TODO change to remove enemies
        public void RemoveNPCs()
        {
            this.currentRoom.removeNPCs();
        }

        public void RemoveNPC(NPC npc)
        {
            this.currentRoom.removeNPC(npc);
        }

        public Item AttemptToTakeItem(string itemName)
        {
            var item = currentRoom.getItem(itemName);
            if(item == null)
            {
                Util.wl("You don't see that Item");
                return null;
            }
            else
            {
                return currentRoom.removeItem(itemName);
            }
        }

        public List<Item> AttemptToOpenItem(string itemName)
        {
            var item = currentRoom.getItem(itemName);
            if(item is Container)
            {
                return ((Container)item).Open();
            }
            else
            {
                Util.wl("You can't open that");
                return new List<Item>();
            }
        }

        public void AddItemToRoom(Item item)
        {
            currentRoom.addItem(item);
        }


        //TODO Add skill check to change text and maybe give different clues
        // maybe instead just have inspect auto call all search for commands?
        public void InspectRoom()
        {
            currentRoom.Inspect();
        }
    }
}
