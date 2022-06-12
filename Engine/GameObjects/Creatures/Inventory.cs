using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using System.Linq;

namespace Text_Based_Adventure.Engine.Player
{
    public class Inventory : List<Item>
    {

        public void addItem(Item item)
        {
            this.Add(item);
        }

        public Item getItem(string name)
        {
            return this.Where(x => x.Name == name).SingleOrDefault();
        }

        /// <summary>
        /// Removes the given Item and returns it
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Item removeItem(string name)
        {
            Item item = this.getItem(name);
            this.Remove(item);
            return item;
        }

        public List<Item> getAllitems()
        {
            return this.ToList();
        }
    }
}
