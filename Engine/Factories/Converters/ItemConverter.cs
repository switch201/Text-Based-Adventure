using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameTools;

namespace Text_Based_Adventure.Engine.Factories.Converters
{
    internal class ItemConverter : Converter<Item>
    {
        public override Item? ReadJson(JsonReader reader, Type objectType, Item? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var item = Create(objectType, jObject);
            return item;
        }

        public override void WriteJson(JsonWriter writer, Item? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override Item Create(Type objectType, JObject jObject)
        {
            //TODO enums or something?
            //if (GetTypeString(jObject) == "Consumable")
            //{
                //var item = jObject.ToObject<Consumable>();

                //if (FieldExists("AttributeModifers", jObject))
                //{
                //    foreach (string mod in jObject["AttributeModifers"])
                //    {
                //        item.AttributeModifers.Add(StatusEffectFactory.MakeAttributeModifierSet(mod));
                //    }
                //}
                //else
                //{
                //    throw new Exception("Consumable json does not have Type AttributeModifers set");
                //}
                //return item;
            //}
            //else if (GetTypeString(jObject) == "Weapon")
            //{
            //    var item = jObject.ToObject<Weapon>();
            //    if (FieldExists("HoldEffects", jObject))
            //    {
            //        foreach (string effect in jObject["HoldEffects"])
            //        {
            //            item.HoldEffects.Add(StatusEffectFactory.MakeAttributeModifierSet(effect));
            //        }
            //    }
            //    return item;

            //}
            //else if (GetTypeString(jObject) == "Container")
            //{
            //    var item = jObject.ToObject<Container>();
            //    foreach (string containerItem in jObject["Items"])
            //    {
            //        item.Items.Add(GameObjectFactory.CreateItem(containerItem));
            //    }
            //    return item;
            //}
            //else
            //{
                
            //}
            var item = jObject.ToObject<Item>();
            return item;
        }
    }
}
