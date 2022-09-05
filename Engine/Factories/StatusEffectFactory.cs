using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;

namespace Text_Based_Adventure.Engine.Factories
{
    public static class StatusEffectFactory
    {
        private static string baseLevelPath = "Content/TestLevel2"; // TODO make this based on the level selected in levelFactory
        public static AttributeModifierSet MakeAttributeModifierSet(string objectName)
        {
            return JsonConvert.DeserializeObject<AttributeModifierSet>(Util.Readfile($"{baseLevelPath}/StatusEffects/{objectName}.json"), itemConverter);

        }
    }
}
