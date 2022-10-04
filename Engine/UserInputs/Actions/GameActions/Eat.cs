using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.UserInputs.MenuTrees;

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
            controller.playerController.TryEatConsumable(seperatedWords.Last(), controller.gameState.getGameTime());
        }

        public override void RespondToInput(GameController controller, string direcObject)
        {
            controller.playerController.TryEatConsumable(direcObject, controller.gameState.getGameTime());
        }

        public override void RespondToInput(GameController controller)
        {
            if (String.IsNullOrEmpty(directObjectString))
            {
                var menu = new EatMenuTree(controller.playerController.player);
                menu.StartMenuTree(controller);
            }
            else
            {
                controller.playerController.TryEatConsumable(directObjectString, controller.gameState.getGameTime());
            }
        }
    }
}
