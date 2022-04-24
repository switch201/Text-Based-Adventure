using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.InputActions
{
    class TalkTo : InputAction
    {
        public override List<string> keyWord => new List<string>() { "talk", "speak", };

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directobject = seperatedWords.Last();
            controller.roomController.TalkToNpc(directobject);
        }
    }
}
