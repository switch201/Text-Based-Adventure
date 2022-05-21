using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Text_Based_Adventure.Engine.Player.Attributes;
using Text_Based_Adventure.Engine.Player.Stats;
using Attribute = Text_Based_Adventure.Engine.Player.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.Player
{
    public class PlayerObject : Creature
    {
        public StatsSet stats;

        public PlayerObject(string name, AttributeSet attributes)
        {
            this.inventory = new Inventory();
            this.stats = new StatsSet();
            this.attributes = attributes;
            this.Name = name;
            this.Health = 5 + attributes.getAttribute(Attribute.Strength);
        }
    }
}
