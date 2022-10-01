using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.Player;
using System.Linq;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;

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
        public int damage;
        public int enemyAttackValue;
        public bool wasValid;
        public bool killingBlow;
        public bool moreEnemies;
        public bool playerKilled;
    }

    public class CombatController
    {
        private PlayerObject? player;
        private List<NPC> enemies;
        private bool gameWon;

        //TODO the whole framework of the combatcontroller needs a redo
        public CombatController()
        {
            enemies = new List<NPC>();
        }

        public void setPlayer(PlayerObject player)
        {
            this.player = player;
        }
        public void setEnemies(List<NPC> enemies)
        {
            this.enemies.AddRange(enemies);
        }

        public void RemoveEnemies()
        {
            enemies.Clear();
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
            return Util.NameOrIdentifier(enemies, nameOrIdentifier);
        }

        public PlayerObject GetPlayer()
        {
            return this.player;
        }

        public int getCombatRunChance()
        {
            var diceRoll = Util.d20();
            var enemyValue = (
                    enemies.Sum(x => x.getFullMod(Attribute.Dexterity)) //Sum of Enemy Agility More Enemies means harder to run away
                );
            if(this.player == null)
            {
                throw new Exception("You can't run with no player in combat ya dingus!!!");
            }
            var playerValue = this.player.getFullMod(Attribute.Dexterity); // Player Agility
            Util.log($"Enemy Run Value {enemyValue}");
            Util.log($"Player Run Value {playerValue}");
            var value = playerValue + diceRoll - enemyValue;
            Util.log($"Run Chance Value {value}");

            return value;
        }

        public int ResolveEnemyAttack(NPC npc)
        {
            //TODO since this can be called from anywhere needs to check if valid

            if(player == null)
            {
                throw new Exception("An NPC can't attack when a player is null ya Dingus!!");
            }

            // Enemy Attacks Back
            int damage = npc.Attack(this.player);

            if (player.Health <= 0)
            {

                //Remove player so game knows hes dead
                this.player = null;
            }
            return damage;
        }

        private bool isEnemyInCombat(NPC npc)
        {
            return enemies.Contains(npc);
        }


        //TODO combine with Resolve Enemy Attack
        public int ResolvePlayerAttack(NPC enemy, Weapon weapon)
        {
            if(player == null)
            {
                throw new Exception("You can't resolve player attack with out a player ya DINGUS");
            }
            int damage = player.Attack(enemy, weapon);
            if (enemy.Health <= 0)
            {
                // drop loot
                //TODO so unbeleiveably broken
                //finalBoss
                if (enemy.Name == "fred")
                {
                    this.gameWon = true;
                }

                //kill enemy
                player.AddXp(enemy.XP);
                enemies.Remove(enemy);
                
            }

            return damage;
        }


    public AttackResult ResolveMeleeAttack(Weapon weapon, string npcName)
        {
            var attackResult = new AttackResult();

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
                };
            }

            if (player.IsCloseTo(enemy) && weapon.WeaponRange == WeaponRange.LongRange)
            {
                Util.fourthWall($"You can't attack with a {weapon.Name} up close.");
                return new AttackResult()
                {
                    wasValid = false,
                };
            }
            if(!player.IsCloseTo(enemy) && weapon.WeaponRange == WeaponRange.CloseRange)
            {
                Util.fourthWall($"You can't attack with a {weapon.Name} at Range.");
                return new AttackResult()
                {
                    wasValid = false,
                };
            }

            attackResult.damage = this.ResolvePlayerAttack(enemy, weapon);


            if (isEnemyInCombat(enemy))
            {
                attackResult.enemyAttackValue = ResolveEnemyAttack(enemy);
            }
            attackResult.wasValid = true;
            return attackResult;
        }
    }
}
