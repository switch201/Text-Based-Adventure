using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Rooms;

namespace Text_Based_Adventure.Engine.Factories.Converters
{
    internal class RoomConverter : GameObjectConverter<Room>
    {
        public override Room? ReadJson(JsonReader reader, Type objectType, Room? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var room = Create(objectType, jObject);
            return room;
        }

        public override void WriteJson(JsonWriter writer, Room? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override Room Create(Type objectType, JObject jObject)
        {
            var room = jObject.ToObject<Room>();
            foreach (string item in jObject["Items"])
            {
                room.addItem(GameObjectFactory.CreateItem(item));
            }
            foreach (string item in jObject["Creatures"])
            {
                room.addNPC((NPC)GameObjectFactory.CreateCreature(item));
            }
            return room;
        }
    }
}
