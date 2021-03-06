using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.GameTools;

namespace Text_Based_Adventure.Engine.GameClasses
{
    public enum Proficiencies
    {
        LightArmor,
        MediumArmor,
        Shields,
        SimpleWeapons,
        MartialWeapons
    }
    public abstract class GameClass
    {
        public string Name;
        public List<int> ProficencyBonus; // Current Proficency Bonus
        public List<int> LevelAmmounts;
        public DiceSet HitDice;
        public int Health;
        public int Level;
        public List<string> Features; // TODO make features class
        public List<Item> StartingInventory;
        public Dictionary<string, int> StartingWeaponsText;
        public List<Proficiencies> Proficiencies;

        public GameClass()
        {
            this.StartingInventory = new List<Item>() { };
        }
    }
}
