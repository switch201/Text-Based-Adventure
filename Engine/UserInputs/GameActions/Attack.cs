using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.InputActions
{
    class Attack : GameAction
    {
        public override List<string> keyWord => new List<string>() { "attack" };

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            //TODO check if there is an NPC that can be attacked
            controller.StartCombat();
        }
    }
}
