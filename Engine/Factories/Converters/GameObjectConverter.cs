using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.Factories.Converters
{
    public abstract class GameObjectConverter<T> : JsonConverter<T> where T : GameObject
    {

        protected abstract T Create(Type objectType, JObject jObject);

        protected string GetTypeString(JObject jObject)
        {
            if(FieldExists("Type", jObject))
            {
                return (string)jObject["Type"];
            }
            else
            {
                throw new Exception($"This GameObject does not have a type: {jObject}");
            }
        }

        protected bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }

        //TODO there is a better way to do this maybe nester deserialization?
        protected void HydrateGameObject(GameObject gameObject, JObject jObject)
        {
            gameObject.DescriptionText = (string)jObject["DescriptionText"];
            gameObject.InspectionText = (string)jObject["Inspectiontext"];
        }
    }
}
