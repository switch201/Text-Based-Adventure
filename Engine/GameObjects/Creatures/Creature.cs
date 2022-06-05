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
        public List<AttributeModifierSet> attributeMods = new List<AttributeModifierSet>(); //list because multiple effects at once
        public Inventory inventory;
        public int Health;
        public int MaxHealth;
        public int chanceToHit; //Inherent Chance to Hit
        public int? AC; //Armor Class
        public ArmorSlots armorSlots;
        public WeaponSlots weaponSlots;
        public string DamageVulnerabilities;
        public string DamageImmunities;
        public string ConditionImmunities;
        public int XP;

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

        public int Attack(Creature defender, Item item = null)
        {
            //TODO since this can be called from anywhere needs to check if valid
            Util.wl($"{this.Name} attacks with a <fill in item>");

            //Calculate Hit Chance 
            Util.log("HitRoll");
            int diceRoll = Util.d20();

            int attackerValue = diceRoll + this.chanceToHit;

            int defenderValue = defender.Dodge();

            int damage = 0;

            if (attackerValue > defenderValue)
            {
                Util.wl($"{Name} lands a hit");
                // Check for item here if null then just punch
                damage = 1 + this.getFullMod(Attribute.Strength);
            }
            else
            {
                Util.wl($"{this.Name}'s attack misses!");
            }

            defender.adjustHealth(-damage);

            Util.log($"DamageValue: {damage}");
            Util.log($"Defender Health After {defender.Health}");
            return damage;

        }

        public int Dodge()
        {
            //TODO always use AC and make sure to keep it up to date
            if(AC != null)
            {
                return (int)AC;
            }
            //This is where meat and potatoes of how items play into attributes and skills comes into play for now "punching" is generalize unarmed combat
            return this.getFullMod(Attribute.Dexterity) + 10; //base dodge;
        }

        public int getFullAttribute(Attribute stat)
        {
            int baseValue = attributes.getAttribute(stat);
            foreach(var attributemod in this.attributeMods)
            {
                baseValue += attributemod.Attributes.getAttribute(stat);
            }
            return baseValue;
        }

        public int getFullMod(Attribute stat)
        {
            return (int)Math.Floor((decimal)(this.getFullAttribute(stat) / 2));
        }

    }
}
