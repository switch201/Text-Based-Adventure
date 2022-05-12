using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.Player;
using Attribute = Text_Based_Adventure.Engine.Player.Attributes.Attribute;
using System.Linq;

namespace Text_Based_Adventure.Engine.Controllers
{
    public class CombatResult
    {
        public int attackValue;
        public bool wasValid;
        public bool killingBlow;
        public bool moreEnemies;
    }

    public class AttackResult
    {
        public int attackValue;
        public bool wasValid;
        public bool killingBlow;
        public bool moreEnemies;
    }

    public class CombatController
    {
        private PlayerObject player;
        private List<NPC> enemies;

        public void setPlayer(PlayerObject player)
        {
            this.player = player;
        }
        public void setEnemies(List<NPC> enemies)
        {
            this.enemies = new List<NPC>();
            this.enemies.AddRange(enemies);
        }

        public void RemoveEnemies()
        {
            this.enemies.Clear();
        }

        public CombatResult GetResult()
        {
            return new CombatResult() {
                moreEnemies = this.GetEnemies().Count() > 0
            };
        }

        public List<NPC> GetEnemies()
        {
            return this.enemies;
        }

        private NPC GetEnemy(string nameOrIdentifier)
        {
            return Util.NameOrIdentifier(this.enemies, nameOrIdentifier);
        }

        public PlayerObject GetPlayer()
        {
            return this.player;
        }

        public AttackResult ResolveMeleeAttack(Item item, string npcName) //TODO needs to be weapons, not all Items can be used in combat;
        {
            NPC enemy = null;
            if (npcName == null)
            {
                enemy = enemies.FirstOrDefault();
            }
            else {
                enemy = GetEnemy(npcName);
            }

            if(enemy == null)
            {
                return new AttackResult() {
                    wasValid = false,
                    attackValue = 0,
                    moreEnemies = false
                };
            }

            int diceRoll = Util.d20();
            Util.log($"DiceRoll: {diceRoll}");

            int baseDodge = 10;

            if (item != null) //TODO different types of unarmed Combat
            {

            }

            int attackValue = GetPlayer().attributes.getAttribute(Attribute.Strength) +
                diceRoll -
                enemy.Attributes.getAttribute(Attribute.Agility) -
                baseDodge;

            if(attackValue > 0)
            {
                enemy.adjustHealth(-attackValue);
            }

            Util.log($"AttackValue: {attackValue}");
            Util.log($"Enemy Health After {enemy.Health}");

            if (enemy.Health <= 0)
            {
                // drop loot

                //kill enemy
                enemies.Remove(enemy);

                return new AttackResult()
                {
                    wasValid = true,
                    attackValue = attackValue,
                    killingBlow = true,
                    moreEnemies = false
                };

            }

            return new AttackResult()
            {
                wasValid = true,
                attackValue = attackValue,
                killingBlow = false,
                moreEnemies = false
            };
        }
    }
}
