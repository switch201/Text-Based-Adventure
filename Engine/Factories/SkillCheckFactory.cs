using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.SkillChecks;
using Text_Based_Adventure.Engine.GameObjects.SkillChecks.ActionSkillChecks;

namespace Text_Based_Adventure.Engine.Factories
{
    public class SkillCheckFactory : Factory
    {
        public static SkillCheck MakeSkillCheck(string itemName)
        {
            SkillCheck item = JsonConvert.DeserializeObject<SkillCheck>(Util.Readfile($"{basePath}/GameObjects/SkillChecks/{itemName}Text.json"));
            item.TriggerAction = UserInput.GetVerb(item.TriggerWord);
            return item;
        }

        public static ActionSkillCheck MakeActionSkillCheck(string itemName)
        {
            ActionSkillCheck item = JsonConvert.DeserializeObject<ActionSkillCheck>(Util.Readfile($"{basePath}/GameObjects/SkillChecks/{itemName}Text.json"));
            item.TriggerAction = UserInput.GetVerb(item.TriggerWord);
            item.SkillAction = UserInput.GetSkillAction(item.SkillWord);
            item.Name = itemName;
            return item;
        }
    }
}
