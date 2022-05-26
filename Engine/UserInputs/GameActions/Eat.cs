using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions
{
    public class Eat : GameAction
    {
        public override List<string> keyWord => new List<string>(){"eat"};

        public override int duration => 2;

        public override string HelpText()
        {
            return "You can eat consumable items from your pack by saying 'eat <itemName>'\n" +
                "You can only eat consumable items. Consumables can effect your health, and/or attributes for a time.";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            controller.playerController.AttemptToEatConsumable(seperatedWords.Last(), controller.gameState.getGameTime());
        }
    }
}
