using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;

namespace Text_Based_Adventure.Engine.InputActions.BattleActions
{
    class RunAway : BattleAction
    {
        public override List<string> keyWord => new List<string>() { "run" };

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            //TODO FIX THIS WHOLE THING!
            controller.RunAway(); //TODO Conditions for running away here;
        }
    }
}
