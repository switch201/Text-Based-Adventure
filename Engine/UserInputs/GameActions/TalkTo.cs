using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.Engine.InputActions
{
    class TalkTo : GameAction
    {
        public override List<string> keyWord => new List<string>() { "talk", "speak", };

        public override int duration => 1;

        public override string HelpText()
        {
            throw new NotImplementedException();
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string directobjectString = seperatedWords.Last();
            var directObject = controller.roomController.TryGetGameObject(directobjectString);
            if(directObject != null)
            {
                if(directObject.Script.React(directObject, this))
                {
                    Util.WriteExceptionSentance("You can't talk to", directobjectString);
                };
            }
            else
            {
                Util.GameObjectNotInRoom(directobjectString);
            }
            controller.roomController.TryTalkToNpc(directobject);
        }
    }
}
