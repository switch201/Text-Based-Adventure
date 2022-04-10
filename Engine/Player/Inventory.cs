using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;

namespace Text_Based_Adventure.Engine.Player
{
    public class Inventory
    {
        Dictionary<string, Item> Items;

        public Inventory()
        {
            Items = new Dictionary<string, Item>() { };
        }

        public void addItem(string name, Item item)
        {
            Items.Add(name, item);
        }

        public Item getItem(string name)
        {
            return Items.GetValueOrDefault(name);
        }

        public Item removeItem(string name)
        {
            Item item = this.getItem(name);
            Items.Remove(name);
            return item;
        }
    }
}
