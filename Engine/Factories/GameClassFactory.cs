using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameClasses;
using System.Linq;

namespace Text_Based_Adventure.Engine.Factories
{
    class GameClassFactory : Factory
    {

        public static GameClass MakeClass(string itemName)
        {
            GameClass item = JsonConvert.DeserializeObject<GameClass>(Util.Readfile($"{basePath}/Classes/{itemName}Text.json"));
            return item;
        }

        public static Barbarian MakeBarbarianClass()
        {
            Barbarian gameClass = JsonConvert.DeserializeObject<Barbarian>(Util.Readfile($"{basePath}/Classes/barbarianText.json"));
            foreach (string itemName in gameClass.StartingWeaponsText.Keys)
            {
                int count = gameClass.StartingWeaponsText.GetValueOrDefault(itemName);
                for (var x = 0; x < count; x++)
                {
                    gameClass.StartingInventory.Add(ItemFactory.MakeWeapon(itemName));
                }
            }
            return gameClass;
        }
    }
}
