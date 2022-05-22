using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Player.Attributes;

namespace Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables
{
    public class Consumable : SmallItem
    {
        public int HealingValue;

        public AttributeSet AttributeModifer;

        public int duration;
    }
}
