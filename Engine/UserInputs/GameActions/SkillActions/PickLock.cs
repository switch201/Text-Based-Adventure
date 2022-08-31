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
            Util.wl("You try to pick the lock but it keeps reseting");
        }

        public override void BestOutcome(GameController? gameController, GameObject? directObject)
        {
            Util.wl("You get the lock open Fast!");
            gameController.gameState.adjustGameClock(-1); // Is this big brain or tiny brain?
            directObject.getActionSkillCheck(this).Locked = false;
        }

        public override void GoodOutcome(GameController? gameController, GameObject? directObject)
        {
            Util.wl("You get the Lock open");
            directObject.getActionSkillCheck(this).Locked = false;
        }

        public override string HelpText()
        {
            return "You can attempt to pick a locked item such as a door or chest." +
                "type 'pick <itemName>' to give it a try";
        }

        public override void WorstOutcome(GameController? gameController, GameObject? directObject)
        {
            Util.wl("*ping* the lock is comprtly broken.");
            directObject.getActionSkillCheck(this).Broken = true;
        }
    }
}
