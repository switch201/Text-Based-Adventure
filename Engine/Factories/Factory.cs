using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.Factories
{
    public abstract class Factory
    {
        public static GameObject MakeGameObject(string itemname)
        {
            return JsonConvert.DeserializeObject<GameObject>(Util.Readfile($"Content/TestLevel/JsonContent/GameObjects/Rooms/{itemname}Text.json"));
        }
    }
}
