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
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Engine.UserInputs.GameActions;

namespace Text_Based_Adventure.Engine
{
    public class RoomController
    {
        public  Room currentRoom;


        public void TryChangeRooms(string direction)
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
            
            List<Item> items = currentRoom.getItems();

            if (items.Count == 0)
            {
                Util.wl("You don't see any items");
            }

            int totalItems = items.Count;
            foreach (var item in items)
            {
                if (item.HasDiscoverText())
                {
                    item.Discover();
                }
                Util.wl($"You see a {item.Name}");
            }
        }

        public void TryInspectSomething(string name, int checkResult)
        {
            //check for items
            Item item = currentRoom.getItem(name);
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

        private void InspectNpc(NPC npc, int checkResult)
        {
            npc.Inspect(checkResult);
        }

        private void InspectItem(Item item, int checkResult)
        {
            item.Inspect();
            item.getQuality();
        }

        public void TryTalkToNpc(string nameOrIdentifier)
        {
            NPC target = this.currentRoom.GetNPC(nameOrIdentifier);

            if (target != null)
            {
                target.SaySmallTalk();
            }
            else
            {
                
            }
        }


        // TODO make Try to Open (not just container)
        public List<Item> TryOpenContainer(string containerName, PlayerObject player)
        {
            var gameAction = UserInput.GetGameAction("open");
            var item = this.currentRoom.getItem(containerName);

            if(item == null)
            {
                GameObjectNotInRoom(containerName);
                return new List<Item>();
            }
            if (!(item is Container))
            {
                Util.WriteExceptionSentance("You can't open", containerName);
                return new List<Item>();
            }
            if (item.hasEvent(gameAction))
            {
                item.TriggerEvent(gameAction, player);
            }
            if (item.isLocked(gameAction)) // TODO should I make key words an enum, and uss that for skill checks?
            {
                GameObjectLocked(item);
                return new List<Item>();
            }
            return ((Container)item).Open();

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

        public void AddItemToRoom(Item item)
        {
            if(item != null)
            {
                currentRoom.addItem(item);
            }
        }


        //TODO Add skill check to change text and maybe give different clues
        // maybe instead just have inspect auto call all search for commands?
        public void InspectRoom()
        {
            currentRoom.Inspect();
        }

        // Will search all gameobject in a room to find match including the room itself.
        public GameObject TryGetGameObject(string name)
        {
            List<GameObject> searchList = new List<GameObject>();
            searchList.AddRange(this.currentRoom.getItems());
            searchList.AddRange(this.currentRoom.getNPCs());
            return searchList.FirstOrDefault(x => x.Name == name);

        }

        private void CheckForEvents(GameObject gameObject)
        {

        }

        private void GameObjectNotInRoom(string itemName)
        {
            Util.WriteExceptionSentance("You don't see", itemName);
        }

        private void GameObjectLocked(GameObject gameObject)
        {
            Util.wl($"The {gameObject.Name} is Locked"); // TODO need to make more unique
        }
    }
}
