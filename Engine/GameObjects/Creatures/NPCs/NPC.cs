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

        public string Name;
        public List<string> Identifiers;
        public List<string> SmallTalk;
        public AttributeSet Attributes;


        public NPC(string npcName) : base("void")
        {
            NPC temp = JsonConvert.DeserializeObject<NPC>(Util.Readfile($"Content/TestLevel/JsonContent/GameObjects/NPCs/{npcName}Text.json"));
            foreach (var property in GetType().GetProperties())
            {
                property.SetValue(this, property.GetValue(temp, null), null);
            }
        }

        public void SaySmallTalk()
        {
            Util.RandomFromList(this.SmallTalk);
        }
    }
}
