using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions
{
    public class Break : SkillAction
    {
        public override List<string> keyWord => new List<string>() { "break" };

        public override int duration => 1;

        public override string HelpText()
        {
            return "Is something in your way and just asking... BEGGING to be smashed into teeny tiny pieces?" +
                "type 'break <itemName>' to try to over come something like a locked door or chest.";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            throw new NotImplementedException();
        }

        public override void BadOutcome(GameController? gameController)
        {
            throw new NotImplementedException();
        }

        public override void BestOutcome(GameController? gameController)
        {
            throw new NotImplementedException();
        }

        public override void GoodOutcome(GameController? gameController)
        {
            throw new NotImplementedException();
        }

        public override void WorstOutcome(GameController? gameController)
        {
            throw new NotImplementedException();
        }
    }
}
