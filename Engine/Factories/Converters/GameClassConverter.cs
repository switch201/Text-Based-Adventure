//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Text_Based_Adventure.Engine.GameClasses;

//namespace Text_Based_Adventure.Engine.Factories.Converters
//{
//    public class GameClassConverter : JsonConverter<GameClass>
//    {
//        public override GameClass? ReadJson(JsonReader reader, Type objectType, GameClass? existingValue, bool hasExistingValue, JsonSerializer serializer)
//        {
//            JObject jObject = JObject.Load(reader);
//            var gameClass = jObject.ToObject<GameClass>();
//            var itemsDictionary = jObject["StartingInventory"].ToObject<Dictionary<string, int>>();
//            foreach (KeyValuePair<string, int> entry in itemsDictionary)
//            {
//                for(var x = 0; x < entry.Value; x++)
//                {
//                    gameClass.StartingInventory.Add(GameObjectFactory.CreateItem(entry.Key));
//                }   
//            }
//            return gameClass;
//        }

//        public override void WriteJson(JsonWriter writer, GameClass? value, JsonSerializer serializer)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
