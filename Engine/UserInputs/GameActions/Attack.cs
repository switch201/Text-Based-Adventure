using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.InputActions
{
    public class Attack : GameAction
    {
        public override List<string> keyWord => new List<string>() { "attack" };

        public override int duration => 0;

        public override string HelpText()
        {
            return "Use Attack to Start Combat";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            //TODO check if there is an NPC that can be attacked
            controller.StartCombat();
        }
    }
}
