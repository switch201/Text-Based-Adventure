using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.InputActions
{
    class Inspect : InputAction
    {
        public override string keyWord => "inspect";

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directObject = seperatedWords.Last();
            if (directObject == "room")
            {
                controller.roomController.InspectRoom();
            }
            else
            {
                //controller.roomController.itemController.InspectItem()
            }
            
        }
    }
}
