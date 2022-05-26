using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.GameObjects;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.GameObjects.Creatures
{
    // Right now a Creature is anything that can participate in combat 
    public abstract class Creature : GameObject
    {
        public AttributeSet attributes;
        public List<AttributeModifierSet> attributeMods; //list because multiple effects at once
        public Inventory inventory;
        public int Health;
        public int MaxHealth;

        public Creature()
        {
            attributeMods = new List<AttributeModifierSet>();
        }


        public void adjustHealth(int adjustment)
        {
            this.Health += adjustment;
            if (this.Health > MaxHealth)
            {
                this.Health = MaxHealth;
            }
            Util.log($"Health Adjusted by {adjustment}");
            Util.log($"Health now at {this.Health}");
        }

        public int Attack(Item item = null)
        {
            Util.log("AttackRoll");
            int diceRoll = Util.d20();

            //This is where meat and potatoes of how items play into attributes and skills comes into play for now "punching" is generalize unarmed combat
            var result = this.attributes.getAttribute(Attribute.Strength) + diceRoll;

            if (result > 10 && result <= 15)
            {
                Util.wl("A Good Attack");
            }
            else if (result > 15)
            {
                Util.wl("A Great Attack");
            }
            else if (result <= 10 && result >= 5)
            {
                Util.wl("A Bad Attack");
            }
            else if (result < 5)
            {
                Util.wl("A Terrible Attack");
            }

            return result;

        }

        public int Dodge()
        {
            //This is where meat and potatoes of how items play into attributes and skills comes into play for now "punching" is generalize unarmed combat
            return this.attributes.getAttribute(Attribute.Agility) + 10; //base dodge;
        }

    }
}
