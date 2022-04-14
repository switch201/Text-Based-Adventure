using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects.Items
{
    public class Item : GameObject
    {

        public string DiscoverText;

        public string GrabText;

        public string QuallityText;

        public Item(string itemName) : base("void")
        {
            //TODO move to Json
            this.name = itemName;
            
            Item temp = JsonConvert.DeserializeObject<Item>(Readfile($"Content/TestLevel/JsonContent/GameObjects/Items/{itemName}Text.json"));
            foreach (var property in GetType().GetProperties())
            {
                property.SetValue(this, property.GetValue(temp, null), null);
            }

        }

        public void Discover()
        {
            Util.wl(this.DiscoverText);
        }

        public bool HasDiscoverText()
        {
            return this.DiscoverText == "";
        }

        public void getQuality()
        {
            Util.wl(this.QuallityText);
        }

        public void Grab()
        {
            Util.wl(this.GrabText);
        }
    }
}
