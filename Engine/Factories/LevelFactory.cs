using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Factories.Converters;
using Text_Based_Adventure.Engine.Levels;

namespace Text_Based_Adventure.Engine.Factories
{
    internal static class LevelFactory
    {
        public static Level? MakeLevel(string levelName)
        {
            return JsonConvert.DeserializeObject<Level>(Util.Readfile($"Content/{levelName}/{levelName}.json"), new LevelConverter());
        }
    }
}
