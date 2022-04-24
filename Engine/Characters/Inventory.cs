using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;

namespace Text_Based_Adventure.Engine.Player
{
    public class Inventory : Dictionary<string, Item>
    {

        public void addItem(Item item)
        {
            this.Add(item.Name, item);
        }

        public Item getItem(string name)
        {
            return this.GetValueOrDefault(name);
        }

        /// <summary>
        /// Removes the given Item and returns it
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Item removeItem(string name)
        {
            Item item = this.getItem(name);
            this.Remove(name);
            return item;
        }
    }
}
