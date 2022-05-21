﻿using System;
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
        public bool moreEnemies;
        public bool playerKilled;
        public bool gameWon;
    }

    public class AttackResult
    {
        public int attackValue;
        public int enemyAttackValue;
        public bool wasValid;
        public bool killingBlow;
        public bool moreEnemies;
        public bool playerKilled;
    }

    public class CombatController
    {
        private PlayerObject player;
        private List<NPC> enemies;
        private bool gameWon;

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
                moreEnemies = this.GetEnemies().Count() > 0,
                playerKilled = this.player == null,
                gameWon = this.gameWon
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


            Util.wl("You attack with a <fill in item>");
            int attackValue = player.Attack() - enemy.Dodge();

            if(attackValue > 0)
            {
                Util.wl("You land a hit");
                enemy.adjustHealth(-attackValue);
            }
            else
            {
                Util.wl("He Dodges your attack!");
            }

            Util.log($"AttackValue: {attackValue}");
            Util.log($"Enemy Health After {enemy.Health}");

            if (enemy.Health <= 0)
            {
                // drop loot

                //finalBoss
                if(enemy.Name == "fred")
                {
                    this.gameWon = true;
                }

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
            else
            {
                // Enemy Attacks Back
                Util.wl("<insert Identifier Here> attacks back.");

                int enemyAttackValue = enemy.Attack() - player.Dodge();

                if (enemyAttackValue > 0)
                {
                    Util.wl("He Hits you!");
                    player.adjustHealth(-enemyAttackValue);
                }
                else
                {
                    Util.wl("You Dodge out of the way.");
                }

                Util.log($"EnemyAttackValue: {enemyAttackValue}");
                Util.log($"Player Health After {player.Health}");

                if(player.Health <= 0)
                {

                    //Remove player so game knows hes dead
                    this.player = null;

                    return new AttackResult()
                    {
                        wasValid = true,
                        attackValue = attackValue,
                        enemyAttackValue = enemyAttackValue,
                        killingBlow = false,
                        moreEnemies = true,
                        playerKilled = true
                    };
                }

                return new AttackResult()
                {
                    wasValid = true,
                    attackValue = attackValue,
                    enemyAttackValue = enemyAttackValue,
                    killingBlow = false,
                    moreEnemies = true,
                    playerKilled = false
                };

            }
        }
    }
}
