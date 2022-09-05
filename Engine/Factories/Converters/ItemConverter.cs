using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Containers;
using Text_Based_Adventure.Engine.GameObjects.Items;
using Text_Based_Adventure.Engine.GameObjects.Items.SmallItems.Consumables;
using Text_Based_Adventure.Engine.GameObjects.Items.Weapons;
using Text_Based_Adventure.Engine.GameTools;

namespace Text_Based_Adventure.Engine.Factories.Converters
{
    public class ItemConverter : GameObjectConverter<Item>
    {
        public override Item? ReadJson(JsonReader reader, Type objectType, Item? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var item = Create(objectType, jObject);
            HydrateGameObject(item, jObject);
            return item;
        }

        public override void WriteJson(JsonWriter writer, Item? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override Item Create(Type objectType, JObject jObject)
        {
            //TODO enums or something?
            if (GetTypeString(jObject) == "Consumable")
            {
                var item = new Consumable();
                HydrateItem(item, jObject);
                if (FieldExists("AttributeModifers", jObject))
                {
                    item.AttributeModifers.Add(StatusEffectFactory.MakeAttributeModifierSet((string)jObject["AttributeModifers"]));
                }
                else {
                    throw new Exception("Consumable json does not have Type AttributeModifers set");
                }
            }
            else if (GetTypeString(jObject) == "Weapon")
            {
                var item = new Weapon();
                HydrateItem(item, jObject);
                if(FieldExists("DiceSet", jObject))
                {
                    item.DiceSet = (DiceSet)jObject["DiceSet"];
                }
                if(FieldExists("HoldEffects", jObject))
                {
                    item.HoldEffects.Add(StatusEffectFactory.MakeAttributeModifierSet((string)jObject["HoldEffects"]));
                }
                Enum.TryParse((string)jObject["DamageType"], out DamageType damageType);
                item.DamageType = damageType;
                return item;

            }
            else if (GetTypeString(jObject) == "Container")
            {
                item = new Container();
            }
            else
            {
                throw new Exception($"Could not find type {GetTypeString(jObject)}");
            }
            return item;
        }

        //TODO there is a better way to do this maybe nester deserialization?
        protected void HydrateItem(Item gameObject, JObject jObject)
        {
            gameObject.QuallityText = (string)jObject["QuallityText"];
        }
    }
}
