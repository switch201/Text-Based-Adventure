using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects;
using Attribute = Text_Based_Adventure.Engine.Player.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.InputActions.BattleActions
{
    public class Punch : BattleAction
    {
        public override List<string> keyWord => new List<string>() { "punch" };

        public override void RespondToInput(CombatController controller, List<string> seperatedWords)
        {
            throw new NotImplementedException();
        }

        public override void RespondToInput(GameController gameController, List<string> seperatedWords)
        {
            CombatController controller = gameController.combatController;
            var enemies = controller.GetEnemies();
            if (seperatedWords.Count == 1 && controller.GetEnemies().Count == 1)
            {
                NPC enemy = enemies.First();
                int diceRoll = r.Next(1, 20);
                int attackValue = controller.GetPlayer().attributes.getAttribute(Attribute.Strength) +
                    diceRoll -
                    enemy.Attributes.getAttribute(Attribute.Agility);
                if (attackValue > 0)
                {
                    Util.wl($"you punch {Util.RandomFromList(enemy.Identifiers)}");
                }
                else
                {
                    Util.wl("you punch misses!!");
                }

            }
        }
    }
}
