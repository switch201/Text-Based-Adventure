using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.InputActions
{
    class TalkTo : GameAction
    {
        public override List<string> keyWord => new List<string>() { "talk", "speak", };

        public override int duration => 1;

        public override string HelpText()
        {
            return "Use talk to speak to creatures!";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directobject = seperatedWords.Last();
            controller.roomController.TryTalkToNpc(directobject);
        }
    }
}
