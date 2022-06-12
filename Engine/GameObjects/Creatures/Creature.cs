using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.GameObjects;
using Weapon = Text_Based_Adventure.Engine.GameObjects.Items.Weapons.Weapon;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables;

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
        public int? AC; //Armor Class
        public ArmorSlots armorSlots;
        public WeaponSlots weaponSlots;
        //public string DamageVulnerabilities;
        //public string DamageImmunities;
        //public string ConditionImmunities;
        public int XP;
        public int ProficiencyBonus;

        public Creature()
        {
            this.inventory = new Inventory();
            this.weaponSlots = new WeaponSlots();
            this.armorSlots = new ArmorSlots();
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

        public int Attack(Creature defender, Weapon weapon = null)
        {
            //TODO since this can be called from anywhere needs to check if valid
            if(weapon == null)
            {
                Util.wl($"{this.Name} attacks with fists");
            }
            else
            {
                Util.wl($"{this.Name} attacks with a {weapon.Name}");
            }

            int strengthMod = this.getFullMod(Attribute.Strength);
            int dexterityMod = this.getFullMod(Attribute.Dexterity);

            Util.log($"Attacker ProficiencyBonus {ProficiencyBonus}");
            Util.log($"Attacker Strength Mod: {strengthMod}");
            Util.log($"Attacker Dex Mod: {dexterityMod}");
            //Calcul(int)it Chance 
            Util.log("HitRoll");
            int diceRoll = Util.d20();

            // TODO Finese and weapon types
            // Chance to hit is d20 + proficiencyBonus + mod
            int attackerValue = diceRoll + this.ProficiencyBonus + strengthMod;
            int defenderValue = defender.Dodge();

            Util.log($"Attacker hit value {attackerValue}");
            Util.log($"Defender AC: {defenderValue}");

            int damage = 0;

            if (attackerValue > defenderValue)
            {
                Util.wl($"{Name} lands a hit");
                if(weapon != null)
                {
                    int damageRoll = weapon.DiceSet.roll();
                    Util.log($"Damage roll: {damageRoll}");
                    // TODO if weapon has finesse can use strength or dex
                    // TODO if ranged weapon then us dex for melee weapons use strength
                    // TODO I think Damage bonus is only for NPCs.....
                    // Damage is damage dice + mod
                    damage = strengthMod + damageRoll;
                }
                else
                {
                    // Punch
                    damage = 1 + strengthMod;
                }
                
                
            }
            else
            {
                Util.wl($"{this.Name}'s attack misses!");
            }

            if(damage > 0)
            {
                defender.adjustHealth(-damage);
            }

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
            return (int)Math.Floor((decimal)((this.getFullAttribute(stat) - 10) / 2));
        }

        public void Equip(Equipable item, string hand = null)
        {
            // Assume right hand sorry left handers.
            if (hand == null)
            {
                if (item is Weapon)
                {
                    this.weaponSlots.setWeapon(WeaponSlot.RightHand, (Weapon)item);
                }
                else
                {
                    // Player should not need to specify slot for armor since it can only go one spot
                    Util.wl("Don't know how to do this yet");
                }

            }
        }

    }
}
