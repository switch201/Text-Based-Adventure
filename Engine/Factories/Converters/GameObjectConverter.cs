using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Actors;

namespace Text_Based_Adventure.Engine.Factories.Converters
{
    internal class GameObjectConverter : Converter<GameObject>
    {
        public static GameObjectType GetGameObjectType(JObject jObject)
        {
            GameObjectType targetType;
            if (FieldExists("Type", jObject))
            {
                if (Enum.TryParse(jObject["Type"].ToString(), out targetType))
                {
                    return targetType;
                }
                else
                {
                    throw new Exception($"{jObject["Type"]} is not a valid GameObjectType: {jObject}");
                }
            }
            else
            {
                throw new Exception($"This GameObject does not have a type: {jObject}");
            }
        }
        public override GameObject? ReadJson(JsonReader reader, Type objectType, GameObject? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var gameObject = Create(objectType, jObject);
            return gameObject;
        }

        public override void WriteJson(JsonWriter writer, GameObject? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override GameObject Create(Type objectType, JObject jObject)
        {
            var gameObjectType = GetGameObjectType(jObject);
            if(gameObjectType == GameObjectType.Item)
            {
                return jObject.ToObject<Item>();
            }
            else if(gameObjectType == GameObjectType.Container)
            {
                var container = jObject.ToObject<Container>();
                foreach (string containerItem in jObject["Inventory"])
                {
                    container.Inventory.Add(GameObjectFactory.CreateGameObject<Item>(containerItem));
                }
                return container;
            }
            else if (gameObjectType == GameObjectType.NPC)
            {
                var npc = jObject.ToObject<NPC>();
                foreach (string containerItem in jObject["Inventory"])
                {
                    npc.Inventory.Add(GameObjectFactory.CreateGameObject<Item>(containerItem));
                }
                return npc;
            }
            return jObject.ToObject<GameObject>();

            //foreach (string item in jObject["Contents"])
            //{
            //    room.Contents.Add(GameObjectFactory.CreateGameObject(item));
            //}
            //foreach (string item in jObject["Creatures"])
            //{
            //    room.addNPC((NPC)GameObjectFactory.CreateCreature(item));
            //}
            //return room;
        }
    }
}
