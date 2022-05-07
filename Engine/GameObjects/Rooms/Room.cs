using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Doors;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.GameObjects;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.Rooms
{
    public class Room : GameObject
    {

        protected Dictionary<string, Room> Exits;

        public Dictionary<string, Door> Doors;

        public Dictionary<string, Item> Items;

        public string EnterText;

        public string ExitText;

        public List<NPC> NPCs;

         public Room(string roomName) : base(roomName)
        {
            Items = new Dictionary<string, Item>() { };
            Exits = new Dictionary<string, Room>() { };
            NPCs = new List<NPC>() { };
        }

        public Room Enter() {
            Util.wl(this.EnterText);
            return this;
        }

        public Room Exit(Room r) {
            Util.wl(this.ExitText);
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

        public void addItem(Item item)
        {
            Items.Add(item.Name, item);
        }

        public Item getItem(string name)
        {
            return Items.GetValueOrDefault(name);
        }

        public void setItems(Dictionary<string, Item> items)
        {
            this.Items = items;
        }

        public Item removeItem(string itemName)
        {
            var item = this.getItem(itemName);
            this.Items.Remove(itemName);
            return item;
        }

        public Dictionary<string, Item> getItems()
        {
            return this.Items;
        }

        public List<NPC> getNPCs()
        {
            return this.NPCs;
        }

        public void addNPC(NPC npc)
        {
            NPCs.Add(npc);
        }

        public NPC GetNPC(string name)
        {
            return Util.NameOrIdentifier(this.NPCs, name);
        }

        public bool removeNPC(NPC npc)
        {
            return NPCs.Remove(npc);
        }
    }
}
