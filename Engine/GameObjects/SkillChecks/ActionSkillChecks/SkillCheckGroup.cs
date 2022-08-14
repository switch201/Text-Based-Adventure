using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.InputActions;

namespace Text_Based_Adventure.Engine.GameObjects.SkillChecks.ActionSkillChecks
{
    public class SkillCheckGroup : List<ActionSkillCheck>
    {
        public string Name;
        public string LockedText;
        public bool IsLocked()
        {
            return this.All(x => x.Locked);
        }

        // All actions in the group NEED to have the same trigger action to make sense I think
        public Verb getTriggerAction()
        {
            var skill = this.FirstOrDefault();
            if(skill != null)
            {
                return skill.TriggerAction;
            }
            return new Go();
        }
    }
}
