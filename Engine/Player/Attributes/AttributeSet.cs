using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Player.Stats;

namespace Text_Based_Adventure.Engine.Player.Attributes
{
    public enum Attribute
    {
        Strength,
        Agility,
        Inteligence,
        Wisdom,
        Perseption
    }

    public class AttributeSet : Dictionary<Attribute, int>
    {
        public AttributeSet()
        {
            foreach (Attribute attribute in Enum.GetValues(typeof(Attribute)))
            {
                this.Add(attribute, 5);
            }
        }

        public void setAttribute(Attribute attribute, int value)
        {
            this.Remove(attribute);
            this.Add(attribute, value);
        }

        public int getStat(Attribute stat)
        {
            return this.GetValueOrDefault(stat);
        }
    }
}
