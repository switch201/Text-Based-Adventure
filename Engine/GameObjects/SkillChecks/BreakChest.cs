using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.InputActions;
using Text_Based_Adventure.Engine.UserInputs.GameActions;

namespace Text_Based_Adventure.Engine.GameObjects.SkillChecks
{
    public class BreakChest : SkillCheck
    {
        public override Verb AttemptedAction => new Open();

        public override Verb SkillAction => throw new NotImplementedException();

        public override void BadOutcome()
        {
            throw new NotImplementedException();
        }

        public override void BestOutcome()
        {
            throw new NotImplementedException();
        }

        public override void GoodOutcome()
        {
            throw new NotImplementedException();
        }

        public override void WorstOutcome()
        {
            throw new NotImplementedException();
        }
    }
}
