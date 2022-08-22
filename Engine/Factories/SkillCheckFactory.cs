using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.SkillChecks;

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

        public static SkillCheckGroup MakeActionSkillCheck(string itemName)
        {
            SkillCheckGroup group = JsonConvert.DeserializeObject<SkillCheckGroup>(Util.Readfile($"{basePath}/GameObjects/SkillChecks/{itemName}Text.json"));
            foreach(ActionSkillCheck check in group)
            {
                check.TriggerAction = UserInput.GetVerb(check.TriggerWord);
                check.SkillAction = UserInput.GetSkillAction(check.SkillWord);
            }
            
            
            group.Name = itemName;
            return group;
        }
    }
}
