using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Containers;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.Factories
{
    class ItemFactory : Factory
    {
        public static Item MakeItem(string itemName)
        {
            Item item = JsonConvert.DeserializeObject<Item>(Util.Readfile($"{basePath}/GameObjects/Items/{itemName}Text.json"));
            item.Name = itemName;
            return item;
        }

        public static Consumable MakeConsumable(string consumableName)
        {
            Consumable item = JsonConvert.DeserializeObject<Consumable>(Util.Readfile($"Content/TestLevel/JsonContent/GameObjects/Items/Consumables/{consumableName}Text.json"));
            item.Name = consumableName;
            return item;
        }

        public static Weapon MakeWeapon(string weaponName)
        {
            Weapon weapon = JsonConvert.DeserializeObject<Weapon>(Util.Readfile($"Content/TestLevel/JsonContent/GameObjects/Items/Weapons/{weaponName}Text.json"));
            weapon.Name = weaponName;
            return weapon;
        }

        public static Container MakeContainer(string itemName)
        {
            Container container = JsonConvert.DeserializeObject<Container>(Util.Readfile($"Content/TestLevel/JsonContent/GameObjects/Items/Containers/{itemName}Text.json"));
            foreach (var item in container.ItemStrings)
            {
                //TODO SO BROKEN!!
                container.Items.Add(ItemFactory.MakeConsumable(item));
            }
            Factory.AttachSkillCheck(container);
            return container;
        }
    }
}
