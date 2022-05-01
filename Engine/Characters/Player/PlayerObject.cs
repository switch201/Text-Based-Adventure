using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Player.Attributes;
using Text_Based_Adventure.Engine.Player.Stats;
using Attribute = Text_Based_Adventure.Engine.Player.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.Player
{
    public class PlayerObject
    {
        public Inventory inventory;
        public StatsSet stats;
        public AttributeSet attributes;
        public string name;
        public int health;

        public PlayerObject(string name, AttributeSet attributes)
        {
            this.inventory = new Inventory();
            this.stats = new StatsSet();
            this.attributes = attributes;
            this.name = name;
            this.health = 5 + attributes.getAttribute(Attribute.Strength);
        }

    }
}
