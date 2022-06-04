using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.GameTools;

namespace Text_Based_Adventure.Engine.GameObjects.Items.Weapons
{
    public enum WeaponType
    {
        MartialMeleeWeapon
    }
    public class Weapon : Item
    {
        public List<AttributeModifierSet> AttributeModifers;
        public DiceSet Damage;
    }
}
