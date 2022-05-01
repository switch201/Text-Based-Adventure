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
            this.enemies = enemies;
        }

        public List<NPC> GetEnemies()
        {
            return this.enemies;
        }

        private NPC getEnemy(string nameOrIdentifier)
        {
            return Util.NameOrIdentifier(this.enemies, nameOrIdentifier);
        }

        public PlayerObject GetPlayer()
        {
            return this.player;
        }

        public CombatResult ResolveMeleeAttack(Item item, string npcName) //TODO needs to be weapons, not all Items can be used in combat;
        {
            NPC enemy = null;
            if (npcName == null)
            {
                enemy = enemies.FirstOrDefault();
            }
            else {
                enemy = getEnemy(npcName);
            }

            if(enemy == null)
            {
                Util.wl("That Person is not here or otherwise can't be reached");
                return new CombatResult() {
                    wasValid = false,
                    attackValue = 0
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

            Util.log($"AttackValue: {attackValue}");
            return new CombatResult()
            {
                wasValid = true,
                attackValue = attackValue
            };
        }
    }
}
