using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.HelpObjects;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions
{
    public class Help : GameAction
    {
        public override List<string> keyWord => new List<string> { "help" };

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            Util.fourthWall(HelpObject.BASE_TEXT);
        }
    }
}
