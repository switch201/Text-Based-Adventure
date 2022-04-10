using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects.Items
{
    public class Item : GameObject
    {
        protected override GameObjectDTO dto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Item(string itemName) : base("void")
        {
            this.name = itemName;
            dto = JsonConvert.DeserializeObject<ItemDTO>(Readfile($"Content/TestLevel/JsonContent/GameObjects/Items/{itemName}Text.json"));
        }

        public void Discover()
        {
            Util.wl(((ItemDTO)dto).DiscoverText);
        }

        public bool HasDiscoverText()
        {
            return ((ItemDTO)dto).DiscoverText == "";
        }

        public void getQuality()
        {
            Util.wl(((ItemDTO)dto).QuallityText);
        }

        public void Grab()
        {
            Util.wl(((ItemDTO)dto).GrabText);
        }
    }
}
