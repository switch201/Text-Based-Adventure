using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.Engine.Factories.Converters
{
    internal abstract class Converter<T> : JsonConverter<T> where T : GameObject
    {

        protected abstract T Create(Type objectType, JObject jObject);

        protected static bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
}
