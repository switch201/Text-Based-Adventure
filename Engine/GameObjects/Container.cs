using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Text_Based_Adventure.Engine.GameVerbs;

namespace Text_Based_Adventure.Engine.GameObjects
{
    internal class Container : Interactable
    {
        [JsonIgnore]
        public List<Item> Inventory = new List<Item>();

        [JsonProperty("inventory")]
        private List<Item> ReadInventory
        {
            get { return Inventory; }
        }

        public Container()
        {
            this.Interactions.Add(new OpenContainer());
        }
    }
}
