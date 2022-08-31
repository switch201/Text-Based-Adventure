using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.InputActions
{
    class Inspect : GameAction
    {
        public override List<string> keyWord => new List<string>() { "inspect", "examine" };

        public override int duration => 0;

        public override string HelpText()
        {
            throw new NotImplementedException();
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directObject = seperatedWords.Last();
            if (directObject == "room")
            {
                controller.roomController.InspectRoom();
            }
            else if (directObject == "self")
            {
                controller.playerController.player.InspectSelf();
            }
            else if (directObject == "inventory")
            {
                controller.playerController.player.InspectInventory();
            }
            else
            {
                int checkResult = controller.playerController.AttributeCheck(Attribute.Wisdom);
                controller.roomController.TryInspectSomething(directObject, checkResult);
            }
            
        }
    }
}
