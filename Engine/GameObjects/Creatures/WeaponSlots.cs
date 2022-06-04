using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;

namespace Text_Based_Adventure.Engine.GameObjects.Creatures
{
    public enum WeaponSlot
    {
        RightHand,
        LeftHand
    }
    public class WeaponSlots : Dictionary<WeaponSlot, Weapon>
    {

    }
}
