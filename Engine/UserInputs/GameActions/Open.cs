using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions
{
    class Open : GameAction
    {
        public override List<string> keyWord => new List<string>() { "open" };

        public override int duration => 1;

        public override string HelpText()
        {
            return "you can open containers by typing 'open <containerName>'";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directObject = seperatedWords.Last();
            controller.playerController.player.Inventory.AddRange(controller.roomController.AttemptToOpenItem(directObject));
        }
    }
}
