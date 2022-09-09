using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Creatures;

namespace Text_Based_Adventure.Engine.Factories.Converters
{
    internal class CreatureConverter : GameObjectConverter<Creature>
    {
        public override Creature? ReadJson(JsonReader reader, Type objectType, Creature? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var item = Create(objectType, jObject);
            return item;
        }

        public override void WriteJson(JsonWriter writer, Creature? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override Creature Create(Type objectType, JObject jObject)
        {
            if (GetTypeString(jObject) == "NPC")
            {
                var npc = jObject.ToObject<NPC>();
                foreach (string action in jObject["Actions"])
                {
                    npc.NPCActions.Add(GameObjectFactory.CreateNPCAction(action));
                }
                return npc;
            }
            else
            {
                throw new Exception("Need Valid Type for NPC");
            }
        }
    }
}
