using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions
{
    public abstract class SkillAction : GameAction
    {
        public abstract void BestOutcome(GameController? gameController);

        public abstract void GoodOutcome(GameController? gameController);

        public abstract void BadOutcome(GameController? gameController);

        public abstract void WorstOutcome(GameController? gameController);
    }
}
