using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables.Armors;

namespace Text_Based_Adventure.Engine.GameObjects.Creatures
{
    public enum ArmorSlot
    {
        Head,
        Chest,
        RightLeg,
        LeftLeg,
        RightArm,
        LeftArm
    }
    class AmorSlots : Dictionary<ArmorSlot, Armor>
    {
    }
}
