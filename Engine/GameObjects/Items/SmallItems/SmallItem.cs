using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.GameObjects.Items
{
    //SmallItems are any item that can be picked up and moved inventory or held
    public abstract class SmallItem : Item
    {

        public SmallItem(string itemName): base(itemName)
        {

        }
    }
}
