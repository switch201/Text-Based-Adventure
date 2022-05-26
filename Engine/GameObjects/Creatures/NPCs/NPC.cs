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
        public List<string> Identifiers;
        public List<string> SmallTalk;
        public bool IsFinalBoss;

        public bool isAlive()
        {
            return Health > 0;
        }

        public void SaySmallTalk()
        {
            Util.wl(Util.RandomFromList(this.SmallTalk));
        }
    }
}
