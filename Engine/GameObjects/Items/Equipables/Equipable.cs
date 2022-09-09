using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;

namespace Text_Based_Adventure.Engine.GameObjects.Items.Equipables
{
    public class Equipable : Item
    {
        public List<AttributeModifierSet> HoldEffects;
    }
}
