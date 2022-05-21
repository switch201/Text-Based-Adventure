using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.Engine.Player.Attributes;
using Text_Based_Adventure.GameObjects;
using Attribute = Text_Based_Adventure.Engine.Player.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.GameObjects.Creatures
{
    // Right now a Creature is anything that can participate in combat 
    public abstract class Creature : GameObject
    {
        public AttributeSet attributes;
        public Inventory inventory;
        public int Health;



        public void adjustHealth(int adjustment)
        {
            this.Health += adjustment;
        }

        public int Attack(Item item = null)
        {
            Util.log("AttackRoll");
            int diceRoll = Util.d20();

            //This is where meat and potatoes of how items play into attributes and skills comes into play for now "punching" is generalize unarmed combat
            var result = this.attributes.getAttribute(Attribute.Strength) + diceRoll;

            if (result > 10 && result <= 15)
            {
                Util.wl("A Good Bunch");
            }
            else if (result > 15)
            {
                Util.wl("A Great Punch");
            }
            else if (result <= 10 && result >= 5)
            {
                Util.wl("A Bad Punch");
            }
            else if (result < 5)
            {
                Util.wl("A Terrible Punch");
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
