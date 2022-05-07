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

        public override void RespondToInput(GameController gameController, List<string> seperatedWords)
        {
            AttackResult result = gameController.combatController.ResolveMeleeAttack(null, seperatedWords.Count > 1 ? seperatedWords.Last() : null);
            if (result.wasValid)
            {
                if (result.killingBlow)
                {
                    Util.wl("Your Punch just blowed his head up");
                }
                else if(result.attackValue > 0 && result.attackValue <= 5)
                {
                    Util.wl("Your punch connects right in the gut. A good hit.");
                }
                else if (result.attackValue > 5)
                {
                    Util.wl("You land a solid blow right to the face");
                }
                else if (result.attackValue <= 0 && result.attackValue >= -5)
                {
                    Util.wl("Your punch connects but doesn't seem to do much of anything");
                }
                else if(result.attackValue < -5)
                {
                    Util.wl("You try to punch but you completely whiff");
                }
            }
        }
    }
}
