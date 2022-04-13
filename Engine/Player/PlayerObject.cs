using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Player.Attributes;
using Text_Based_Adventure.Engine.Player.Stats;

namespace Text_Based_Adventure.Engine.Player
{
    public class PlayerObject
    {
        public Inventory inventory;
        public StatsSet stats;
        public AttributeSet attributes;
        public string name;

        //TODO Create a Character?
        public PlayerObject(string name)
        {
            this.inventory = new Inventory();
            this.stats = new StatsSet();
            this.attributes = new AttributeSet();
            this.name = name;
        }

        public PlayerObject(string name, AttributeSet attributes)
        {
            this.inventory = new Inventory();
            this.stats = new StatsSet();
            this.attributes = attributes;
            this.name = name;
        }

    }
}
