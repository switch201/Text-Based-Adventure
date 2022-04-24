using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Player.Attributes;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects
{
    public class NPC : GameObject
    {
        public List<string> Identifiers;
        public List<string> SmallTalk;
        public AttributeSet Attributes;


        public NPC(string npcName) : base(npcName)
        {

        }

        public void SaySmallTalk()
        {
            Util.wl(Util.RandomFromList(this.SmallTalk));
        }
    }
}
