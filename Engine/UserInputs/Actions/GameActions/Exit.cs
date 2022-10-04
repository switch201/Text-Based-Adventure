using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions
{
    class Exit : GameAction
    {
        public override List<string> keyWord => new List<string>() { "exit", "leave", };

        public override int duration => 0;

        public override string HelpText()
        {
            return "Use Exit to exit the game!";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            controller.ExitGame();
        }

        public override void RespondToInput(GameController controller, string direcObject)
        {
            throw new NotImplementedException();
        }

        public override void RespondToInput(GameController controller)
        {
            throw new NotImplementedException();
        }
    }
}
