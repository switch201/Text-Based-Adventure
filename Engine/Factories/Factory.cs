using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.Factories
{
    public abstract class Factory
    {

        protected static string basePath = "Content/TestLevel/JsonContent";
        public static GameObject MakeGameObject(string itemname)
        {
            return JsonConvert.DeserializeObject<GameObject>(Util.Readfile($"{basePath}/GameObjects/Rooms/{itemname}Text.json"));
        }

        protected static GameObject AttachSkillCheck(GameObject gameObject)
        {
            foreach(string name in gameObject.SkillCheckNames)
            {
                gameObject.SkillChecks.Add(SkillCheckFactory.MakeActionSkillCheck(name));
            }
            return gameObject;
        }
    }
}
