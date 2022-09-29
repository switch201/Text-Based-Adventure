using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Text_Based_Adventure.Engine.GameObjects.Creatures.NPCs;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects
{
    public class NPC : Creature
    {
        public int XP;
        public List<NPCAction> NPCActions;
        public int AC; //Armor Class

        public NPC()
        {
            NPCActions = new List<NPCAction>();
        }
        public bool isAlive()
        {
            return Health > 0;
        }

        public int Attack(Creature defender)
        {
            var action = Util.RandomFromList(this.NPCActions);

            Util.log($"Attacker Hit Bonus {action.AttackBonus}");
            //Calcul(int)it Chance 
            Util.log("HitRoll");
            int diceRoll = Util.d20();

            // TODO Finese and weapon types
            // Chance to hit is d20 + proficiencyBonus + mod
            int attackerValue = diceRoll + action.AttackBonus;
            int defenderValue = defender.Dodge();

            Util.log($"Attacker hit value {attackerValue}");
            Util.log($"Defender AC: {defenderValue}");

            int damage = action.DamageDice.roll();

            Util.log($"Attack Damage Dice Count: {action.DamageDice.Count} Sides: {action.DamageDice.Sides} Mod: {action.DamageDice.Mod}");

            Util.wl($"{this.Name} attacks with {Util.RandomFromList(action.AttackDescriptions)}");
            if (attackerValue > defenderValue)
            {
                Util.wl($"{this.Name} lands a hit!");
                defender.adjustHealth(-damage);
            }
            else
            {
                Util.wl($"{this.Name}'s attack misses!");
            }

            Util.log($"DamageValue: {damage}");
            Util.log($"Defender Health After {defender.Health}");
            return damage;
        }

        public override int Dodge()
        {
            return AC;
        }
    }
}
