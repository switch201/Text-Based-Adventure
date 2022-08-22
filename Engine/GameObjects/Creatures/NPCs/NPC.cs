using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects
{
    public class NPC : Creature
    {
        public List<string> SmallTalk;
        public bool IsFinalBoss;
        public List<string> Weapons;
        public int XP;

        public bool isAlive()
        {
            return Health > 0;
        }

        public void SaySmallTalk()
        {
            Util.wl(Util.RandomFromList(this.SmallTalk));
        }

        public void Inspect(int checkValue)
        {
            base.Inspect();
            if(checkValue > 10)
            {
                var heldWeapon = this.weaponSlots.getWeapon(WeaponSlot.RightHand);
                if (heldWeapon != null)
                {
                    Util.wl($"{this.Name} is holding a {heldWeapon.Name}.");
                }
                else
                {
                    Util.wl($"{this.Name} is not holding anything.");
                }
            }
            if(checkValue > 15)
            {

            }
            if(checkValue > 20)
            {

            }

        }
    }
}
