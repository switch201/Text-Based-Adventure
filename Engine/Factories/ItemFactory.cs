using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.Factories
{
    class ItemFactory : Factory
    {
        public static Item MakeItem(string itemName)
        {
            Item item = JsonConvert.DeserializeObject<Item>(Util.Readfile($"Content/TestLevel/JsonContent/GameObjects/Items/{itemName}Text.json"));
            item.Name = itemName;
            return item;
        }

        public static Consumable MakeConsumable(string consumableName)
        {
            Consumable item = JsonConvert.DeserializeObject<Consumable>(Util.Readfile($"Content/TestLevel/JsonContent/GameObjects/Items/Comsumables/{consumableName}Text.json"));
            item.Name = consumableName;
            return item;
        }
    }
}
