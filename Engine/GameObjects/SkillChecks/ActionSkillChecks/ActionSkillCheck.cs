using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.InputActions;

namespace Text_Based_Adventure.Engine.GameObjects.SkillChecks.ActionSkillChecks
{
    public abstract class ActionSkillCheck : SkillCheck
    {
        public bool Locked;
        public bool Broken;

        public abstract Verb SkillAction { get; }
    }
}
