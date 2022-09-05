using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Doors;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.GameObjects;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Creatures;

namespace Text_Based_Adventure.Rooms
{
    public class Room : GameObject
    {

        protected Dictionary<string, Room> Exits;

        public Dictionary<string, Door> Doors;

        public List<Item> Items;

        public string EnterText;

        public string ExitText;

        public List<Creature> Creatures;

        public int runModifier; // how easy is it to run away from a fight in this "Room"

         public Room()
        {
            Items = new List<Item>() { };
            Exits = new Dictionary<string, Room>() { };
            Creatures = new List<Creature>() { };
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
            Items.Add(item);
        }

        public void addItems(List<Item> items)
        {
            this.Items.AddRange(items);
        }

        public Item getItem(string name)
        {
            return Items.Where(x => x.Name.Equals(name) || x.Identifiers.Contains(name))
                .SingleOrDefault();
        }

        public void setItems(List<Item> items)
        {
            this.Items = items;
        }

        public Item removeItem(string itemName)
        {
            var item = this.getItem(itemName);
            this.Items.Remove(item);
            return item;
        }

        public List<Item> getItems()
        {
            return this.Items;
        }

        public List<Creature> getNPCs()
        {
            return this.Creatures;
        }

        public void addNPC(Creature npc)
        {
            Creatures.Add(npc);
        }

        public Creature GetNPC(string name)
        {
            return Util.NameOrIdentifier(this.Creatures, name);
        }

        public bool removeNPC(NPC npc)
        {
            return Creatures.Remove(npc);
        }

        public void removeNPCs()
        {
            Creatures.Clear();
        }
    }
}
