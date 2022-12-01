using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Text_Based_Adventure.Engine.GameActions;

namespace Text_Based_Adventure.Engine.GameObjects
{
    internal class Container : Interactable
    {
        [JsonIgnore]
        public List<Item> Inventory = new List<Item>();

        public Container()
        {
            this.Interactions.Add(new OpenContainer());
        }
    }
}
