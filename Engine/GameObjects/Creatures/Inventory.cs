using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using System.Linq;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.Player
{
    public class Inventory : List<Item>
    {

        public void AddItem(Item item)
        {
            this.Add(item);
        }

        public Item GetItem(string name)
        {
            return Util.NameOrIdentifier(this, name);
        }

        /// <summary>
        /// Removes the given Item and returns it
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Item RemoveItem(string name)
        {
            Item item = this.GetItem(name);
            this.Remove(item);
            return item;
        }

        public List<Item> GetAllitems()
        {
            return this.ToList();
        }

        public bool IsItemInInventory(string itemName)
        {
            return GetItem(itemName) != null;
        }
    }
}
