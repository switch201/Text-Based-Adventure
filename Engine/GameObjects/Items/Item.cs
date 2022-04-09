using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects.Items
{
    public abstract class Item : GameObject
    {

        public Item(string itemName) : base("void")
        {
            this.name = itemName;
            dto = JsonConvert.DeserializeObject<ItemDTO>(Readfile($"Content/TestLevel/JsonContent/GameObjects/Items/{itemName}Text.json"));
        }
    }
}
