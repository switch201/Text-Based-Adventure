using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions;

namespace Text_Based_Adventure.Engine.GameObjects.SkillChecks
{
    public class ActionSkillCheck : SkillCheck
    {
        public bool Locked;

        public SkillAction SkillAction;

        public string SkillWord;

        public string BrokenText;

        public string LockedText;
    }
}
