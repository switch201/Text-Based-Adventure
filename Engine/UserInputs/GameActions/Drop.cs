using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects.Items;

namespace Text_Based_Adventure.Engine.InputActions
{
    class Drop : GameAction
    {
        public override List<string> keyWord => new List<string>() { "drop", "place" };

        public override int duration => 0;

        public override string HelpText()
        {
            return "Use Drop to to remove an item from your inventory!";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directobject = seperatedWords.Last();
            controller.roomController.AddItemToRoom(controller.playerController.TryDropItem(directobject));
        }
    }
}
