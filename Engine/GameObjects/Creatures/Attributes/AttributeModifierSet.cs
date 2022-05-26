using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes
{
    public class AttributeModifierSet
    {
        public AttributeSet Attributes;
        public string Name;
        public int Duration;// lets say -1 is forever for now... could do better.
        public int StartTime;
    }
}
