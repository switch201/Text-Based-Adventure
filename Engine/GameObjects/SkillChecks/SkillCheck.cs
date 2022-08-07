using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.InputActions;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.GameObjects.SkillChecks
{
    public abstract class SkillCheck
    {
        AttributeSet AttributeSet; // The Attributes checks you need to pass for this skill check (can be a combo)

        // The action that cause the skill check to happen
        // The thing you are trying to do  For passive skills it happens automatically
        // For action skills its the thing you are trying to do.
        public abstract Verb TriggerAction { get; } 

        public abstract void BestOutcome();

        public abstract void GoodOutcome();

        public abstract void BadOutcome();

        public abstract void WorstOutcome();
    }
}
