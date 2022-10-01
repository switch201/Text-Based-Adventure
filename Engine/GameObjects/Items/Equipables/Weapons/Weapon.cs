using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.GameObjects.Items.Equipables;
using Text_Based_Adventure.Engine.GameTools;

namespace Text_Based_Adventure.Engine.GameObjects.Items.Weapons
{
    public enum WeaponType
    {
        MartialMeleeWeapon
    }

    public enum DamageType
    {
        Piercing,
        Slashing
    }
    public enum WeaponRange
    {
        CloseRange,
        LongRange,
        Both
    }
    public class Weapon : Equipable
    {
        public DiceSet DiceSet;
        public WeaponRange WeaponRange;
        public DamageType DamageType; // TODO will I need a list?
    }
}
