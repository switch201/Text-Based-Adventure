using System;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.Engine.Player.Stats;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;

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
            this.weaponSlots = new WeaponSlots();
            this.armorSlots = new ArmorSlots();
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
        }

        //TODO maybe all creatures can eat?
        public void Eat(Consumable item, int gameTime)
        {
            // TODO what happens with poison and you die outside of battle?
            adjustHealth(item.HealingValue);
            item.AttributeModifers.ForEach(x => x.StartTime = gameTime + 2); //+2 is to offset the fact Eating takes 2 units of time.
            attributeMods.AddRange(item.AttributeModifers);
        }

        
        public void Equip(Equipable item, string hand = null)
        {
            // Assume right hand sorry left handers.
            if(hand == null)
            {
                if(item is Weapon)
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
