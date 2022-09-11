using System;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.Engine.Player.Stats;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;
using Text_Based_Adventure.Engine.GameClasses;
using System.Collections.Generic;

namespace Text_Based_Adventure.Engine.Player
{
    public class PlayerObject : Creature
    {
        public StatsSet stats;
        public double XP;
        public GameClass playerClass;
        public ArmorSlots armorSlots;
        public WeaponSlots weaponSlots;
        public int ProficiencyBonus;

        public PlayerObject(string name, AttributeSet attributes, GameClass playerClass, List<Skill> selectedSkills ) : base()
        {
            this.playerClass = playerClass;
            this.stats = new StatsSet();
            this.attributes = attributes;
            this.Name = name;
            this.Health = this.MaxHealth = playerClass.HitDice.Count * playerClass.HitDice.Sides + this.getFullMod(Attribute.Constitution);
            this.XP = 0;
            this.ProficiencyBonus = playerClass.ProficencyBonus.First();
            this.Inventory.AddRange(playerClass.StartingInventory);
            this.skills = selectedSkills;
            this.weaponSlots = new WeaponSlots();
        }

        public void AddXp(double xp)
        {
            this.XP += xp;
        }

        private void AdjustAttribute(Attribute attribute, int ammount)
        {
            Util.log($"Adjusting Attribute {attribute} by {ammount}");
            this.attributes.setAttribute(attribute, this.attributes.getAttribute(attribute) + ammount);
        }

        public void CheckConsumableTimeAndRemove(int gameTime)
        {
            foreach(var mod in attributeMods.ToList())
            {
                if(gameTime >= mod.StartTime + mod.Duration)
                {
                    this.attributeMods.Remove(mod);
                }
            }
        }

        public void InspectSelf()
        {
            Util.fourthWall("Well if you have had to rate yourself...");
            foreach(Attribute attribute in Enum.GetValues(typeof(Attribute)))
            {
                Util.fourthWall($"Your {attribute} is {this.attributes.getAttribute(attribute)}");
            }
            Util.fourthWall($"Don't Forget your Attribute Mods");
            foreach(var mod in attributeMods)
            {
                Util.fourthWall($"{mod.Name} is giving you...");
                foreach (Attribute attribute in Enum.GetValues(typeof(Attribute)))
                {
                    int modValue = mod.Attributes.getAttribute(attribute);
                    if (modValue != 0)
                    {
                        Util.fourthWall($"{modValue} {attribute}");
                    }
                }
            }
            Util.fourthWall($"Your current Health is {Health}");
            Util.fourthWall("These are your equipped items");
            foreach(var slot in weaponSlots)
            {
                Weapon weapon = slot.Value;
                WeaponSlot hand = slot.Key;
                if(weapon != null)
                {
                    Util.fourthWall($"You are holding a {weapon.Name} in your {hand} hand");
                }
            }
            Util.fourthWall($"You have {this.XP} XP");
        }

        public void InspectInventory()
        {
            Util.fourthWall("You are carrying...");
            var inventoryGroups = this.Inventory.GroupBy(x => x.Name);
            foreach(var inventoryGroup in inventoryGroups)
            {
                var itemCount = inventoryGroup.Count();
                if (itemCount > 1)
                {
                    Util.wl($"{inventoryGroup.First().Name} ({itemCount})");
                }
                else
                {
                    Util.wl(inventoryGroup.First().Name);
                }
                
            }
        }

        //TODO maybe all creatures can eat?
        public void Eat(Consumable item, int gameTime)
        {
            // TODO what happens with poison and you die outside of battle?
            adjustHealth(item.HealingValue);
            item.AttributeModifers.ForEach(x => x.StartTime = gameTime + 2); //+2 is to offset the fact Eating takes 2 units of time.
            attributeMods.AddRange(item.AttributeModifers);
        }

        public int Attack(Creature defender, Weapon weapon)
        {
            //TODO since this can be called from anywhere needs to check if valid
            if (weapon == null)
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
                if (weapon != null)
                {
                    int damageRoll = weapon.DiceSet.roll();
                    Util.log($"Damage roll: {damageRoll}");
                    // TODO if weapon has finesse can use strength or dex
                    // TODO if ranged weapon then us dex for melee weapons use strength
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

            if (damage > 0)
            {
                defender.adjustHealth(-damage);
            }

            Util.log($"DamageValue: {damage}");
            Util.log($"Defender Health After {defender.Health}");
            return damage;

        }

        public override int Dodge()
        {
            return this.getFullMod(Attribute.Dexterity) + 10; //base dodge;
        }

        public void Equip(Equipable item, WeaponSlot hand)
        {
            if (item is Weapon)
            {
                this.weaponSlots.setWeapon(hand, (Weapon)item);
            }
            else
            {
                // Player should not need to specify slot for armor since it can only go one spot
                Util.wl("Don't know how to do this yet");
            }
        }
    }
}
