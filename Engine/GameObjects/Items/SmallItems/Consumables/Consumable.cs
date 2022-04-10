using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables
{
    public class Consumable : SmallItem
    {

        public Consumable(string itemName) : base(itemName)
        {

        }

        protected override GameObjectDTO dto { get; set; }
    }
}
