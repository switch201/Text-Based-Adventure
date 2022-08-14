using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions
{
    public class PickLock : SkillAction
    {
        public override List<string> keyWord => new List<string>() { "pick", "lockpick", "picklock" };

        public override int duration => 2;

        public override void BadOutcome(GameController? gameController, GameObject? directObject)
        {
            throw new NotImplementedException();
        }

        public override void BestOutcome(GameController? gameController, GameObject? directObject)
        {
            throw new NotImplementedException();
        }

        public override void GoodOutcome(GameController? gameController, GameObject? directObject)
        {
            throw new NotImplementedException();
        }

        public override string HelpText()
        {
            return "You can attempt to pick a locked item such as a door or chest." +
                "type 'pick <itemName>' to give it a try";
        }

        public override void WorstOutcome(GameController? gameController, GameObject? directObject)
        {
            throw new NotImplementedException();
        }
    }
}
