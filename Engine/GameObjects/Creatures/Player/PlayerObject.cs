using System;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
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
            this.Health = this.MaxHealth = 5 + attributes.getAttribute(Attribute.Strength);
        }

        private void AdjustAttribute(Attribute attribute, int ammount)
        {
            Util.log($"Adjusting Attribute {attribute} by {ammount}");
            this.attributes.setAttribute(attribute, this.attributes.getAttribute(attribute) + ammount);
        }

        public void InspectSelf()
        {
            Util.fourthWall("Well if you have had to rate yourself...");
            foreach(Attribute attribute in Enum.GetValues(typeof(Attribute)))
            {
                Util.fourthWall($"Your {attribute} is {this.attributes.getAttribute(attribute)}");
            }
            Util.fourthWall($"Your current Health is {Health}");
        }

        public void Eat(Consumable item)
        {
            if (item.HealingValue != null)
            {
                // TODO what happens with poison and you die outside of battle?
                adjustHealth(item.HealingValue);
            }
            foreach (Attribute attribute in Enum.GetValues(typeof(Attribute)))
            {
                this.AdjustAttribute(attribute, item.AttributeModifer.getAttribute(attribute));
            }
        }
}
}
