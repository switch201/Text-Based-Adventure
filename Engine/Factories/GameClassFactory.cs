//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Text_Based_Adventure.Engine.GameClasses;
//using System.Linq;
//using Text_Based_Adventure.Engine.Factories.Converters;

//namespace Text_Based_Adventure.Engine.Factories
//{
//    class GameClassFactory //TODO only thing it gets from base class is basePath
//    {
//        protected static string basePath = "Content/TestLevel2/GameClasses";
//        public static GameClass MakeClass(string itemName)
//        {
//            GameClass item = JsonConvert.DeserializeObject<GameClass>(Util.Readfile($"{basePath}/{itemName}.json"), new GameClassConverter());
//            return item;
//        }
//    }
//}
