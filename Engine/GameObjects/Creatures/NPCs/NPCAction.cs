using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;
using Text_Based_Adventure.Engine.GameTools;

namespace Text_Based_Adventure.Engine.GameObjects.Creatures.NPCs
{
    public class NPCAction
    {
        public DamageType DamageType;
        public List<string> AttackDescriptions;
        public string Description;
        public int AttackBonus;
        public DiceSet DamageDice;
        public int DamageBonus;
        public bool Legendary;
        public bool Reaction;
    }
}
