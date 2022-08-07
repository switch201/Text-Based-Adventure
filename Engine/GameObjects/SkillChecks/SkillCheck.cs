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
        public abstract Verb AttemptedAction { get; }
        public abstract Verb SkillAction { get; }
        AttributeSet AttributeSet;

        public bool Locked;
        public bool Broken;

        public abstract void BestOutcome();

        public abstract void GoodOutcome();

        public abstract void BadOutcome();

        public abstract void WorstOutcome();
    }
}
