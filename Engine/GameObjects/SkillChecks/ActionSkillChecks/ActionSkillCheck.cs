using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.InputActions;
using Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions;

namespace Text_Based_Adventure.Engine.GameObjects.SkillChecks.ActionSkillChecks
{
    public class ActionSkillCheck : SkillCheck
    {
        public bool Locked;
        public bool Broken; // When true skill check can no longer be attempted

        public SkillAction SkillAction;

        public string SkillWord;
    }
}
