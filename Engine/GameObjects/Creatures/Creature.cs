using System;
using System.Collections.Generic;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.GameObjects;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using Weapon = Text_Based_Adventure.Engine.GameObjects.Items.Weapons.Weapon;

namespace Text_Based_Adventure.Engine.GameObjects.Creatures
{
    // Right now a Creature is anything that can participate in combat
    // A Create is both a player and an NPC. NPCs can have quests tied to them, and the player is the player,
    // Anything that is just a creatrue then is just something you can fight. If a creature is tied to a quest in some way
    // Then that Creature should instead be an NPC
    public abstract class Creature : GameObject
    {
        public AttributeSet attributes;
        public List<Skill> skills;

        // List of things that might be modifying your attributes like food or spells
        public List<AttributeModifierSet> attributeMods = new List<AttributeModifierSet>(); //list because multiple effects at once
        public Inventory Inventory;
        public int Health;
        public int MaxHealth;
        //public string DamageVulnerabilities;
        //public string DamageImmunities;
        //public string ConditionImmunities;
        public double XP;

        public Creature()
        {
            this.Inventory = new Inventory();
            this.skills = new List<Skill>() { };
        }

        public bool hasSkill(Skill skill)
        {
            return this.skills.Contains(skill);
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

        public abstract int Dodge();

        // used for Attribute mod calculation on the fly
        public int getFullAttribute(Attribute stat)
        {
            int baseValue = attributes.getAttribute(stat);
            foreach(var attributemod in this.attributeMods)
            {
                baseValue += attributemod.Attributes.getAttribute(stat);
            }
            return baseValue;
        }

        // Gets the attribute mod for the given attribute with bonues applied
        public int getFullMod(Attribute stat)
        {
            return (int)Math.Floor((decimal)((this.getFullAttribute(stat) - 10) / 2));
        }

        public int AttributeCheck(Attribute attr)
        {
            return Util.d20() + (int)this.getFullMod(attr);
        }
    }
}
