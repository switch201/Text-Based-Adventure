using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.InputActions;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.GameObjects
{
    public abstract class SkillCheck
    {
        Verb Verb;
        AttributeSet AttributeSet;

        public abstract void BestOutcome();

        public abstract void GoodOutcome();

        public abstract void BadOutcome();

        public abstract void WorstOutcome();
    }
}
