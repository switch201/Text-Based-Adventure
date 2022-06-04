using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions
{
    class Equip : GameAction
    {
        public override List<string> keyWord => new List<string>() { "equip" };

        public override int duration => 1;

        public override string HelpText()
        {
            return "You can equip items from your inventory by typing 'equip <itemName>";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directObject = seperatedWords.Last();
            controller.playerController.AttemptToEquipItem(directObject);
        }
    }
}
