using System;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.Engine.Player.Stats;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;
using Text_Based_Adventure.Engine.GameClasses;

namespace Text_Based_Adventure.Engine.Player
{
    public class PlayerObject : Creature
    {
        public StatsSet stats;
        public int XP;
        public GameClass playerClass;

        public PlayerObject(string name, AttributeSet attributes) : base()
        {
            this.stats = new StatsSet();
            this.attributes = attributes;
            this.Name = name;
            this.Health = this.MaxHealth = 5 + attributes.getAttribute(Attribute.Strength);
            this.XP = 0;
            this.ProficiencyBonus = 0;
        }
        public void AddXp(int xp)
        {
            this.XP += xp;
        }



        public PlayerObject(string name, AttributeSet attributes, GameClass playerClass ) : base()
        {
            this.playerClass = playerClass;
            this.stats = new StatsSet();
            this.attributes = attributes;
            this.Name = name;
            this.Health = this.MaxHealth = playerClass.HitDice.Count * playerClass.HitDice.Sides;
            this.XP = 0;
            this.ProficiencyBonus = playerClass.ProficencyBonus.First();
            this.Inventory.AddRange(playerClass.StartingInventory);
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

        
        public new void Equip(Equipable item, string hand = null)
        {
            base.Equip(item, hand);
        }
}
}
