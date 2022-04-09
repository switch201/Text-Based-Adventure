using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.GameObjects.Items
{
    public abstract class Item : GameObject
    {
        public string name;

        public Item(string itemName)
        {
            this.name = itemName;
            dto = JsonConvert.DeserializeObject<ItemDTO>(Readfile($"Engine/GameObjects/Items/{itemName}.json"));
        }
    }
}
