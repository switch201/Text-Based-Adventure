using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.InputActions
{
    class Exit : InputAction
    {
        public override List<string> keyWord => new List<string>() { "exit", "leave", };

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            controller.ExitGame();
        }
    }
}
