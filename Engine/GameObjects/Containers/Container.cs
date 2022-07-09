using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects.Containers
{
    public class Container : Item
    {
        public List<Item> Items;
        public LockObject LockObject;
        public List<string> ItemStrings;

        public List<Item> Open()
        {
            Util.fourthWall("Type 'take all' to take all.");
            Util.fourthWall("'take <itemName>' to take a specific item");
            Util.fourthWall("'exit' to exit");
            string userInput = null;
            List<Item> returnedItems = new List<Item>();
            while(userInput != "exit")
            {
                if(Items.Count == 0)
                {
                    Util.wl("The container is empty");
                }
                else
                {
                    foreach (var item in Items)
                    {
                        Util.wl($"This container contains a {item.Name}");
                    }
                }
                userInput = Util.rl();
                if (userInput == "take all")
                {
                    Util.wl("You take all the items");
                    foreach (var item in Items)
                    {
                        returnedItems.Add(item);
                        Items.Remove(item);
                    }
                }
            }
            return returnedItems;
        }
    }
}
