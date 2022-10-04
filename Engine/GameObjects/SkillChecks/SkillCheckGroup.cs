using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.UserInputs.Actions;
using Text_Based_Adventure.Engine.UserInputs.GameActions;

namespace Text_Based_Adventure.Engine.GameObjects.SkillChecks
{
    public class SkillCheckGroup : List<ActionSkillCheck>
    {
        // All Locks in a SkillCheck Group need to be unlocked before the whole group is considered unlocked.
        // This is to group skill checks in series like jumping off a cliff and grabing a rope. which might combine Athletasism
        // and strength
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
            if (skill != null)
            {
                return skill.TriggerAction;
            }
            return new Go();
        }
    }
}
