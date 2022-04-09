using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.InputActions
{
    class Inspect : InputAction
    {
        public override string keyWord => "inspect";

        public override void RespondToInput(GameController controller, string[] seperatedWords)
        {
            if(seperatedWords[1] == "room")
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
