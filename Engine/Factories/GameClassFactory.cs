using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameClasses;

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
            Barbarian item = JsonConvert.DeserializeObject<Barbarian>(Util.Readfile($"{basePath}/Classes/batbarianText.json"));
            return item;
        }
    }
}
