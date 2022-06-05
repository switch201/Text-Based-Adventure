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

        public WeaponSlots()
        {
            foreach (WeaponSlot slot in Enum.GetValues(typeof(WeaponSlot)))
            {
                this.Add(slot, null);
            }
        }

        public void setWeapon(WeaponSlot slot, Weapon weapon) //TODO what about sheilds are they weapons too?
        {
            this.Remove(slot);
            this.Add(slot, weapon);
        }

        public Weapon getWeapon(WeaponSlot slot)
        {
            return this.GetValueOrDefault(slot);
        }

    }
}
