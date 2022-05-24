using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using System.Linq;

namespace Text_Based_Adventure.Engine.InputActions.BattleActions
{
    public class Punch : BattleAction
    {
        public override List<string> keyWord => new List<string>() { "punch" };

        public override int duration => 1;

        public override string HelpText()
        {
            throw new NotImplementedException();
        }

        public override void RespondToInput(GameController gameController, List<string> seperatedWords)
        {
            AttackResult result = gameController.combatController.ResolveMeleeAttack(null, seperatedWords.Count > 1 ? seperatedWords.Last() : null);
            if (!result.wasValid)
            {
                Util.wl("You can't punch this person");
            }
        }
    }
}
