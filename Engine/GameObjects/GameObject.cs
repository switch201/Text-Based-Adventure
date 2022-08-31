using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.SkillChecks;
using Text_Based_Adventure.Engine.GameObjects.SkillChecks.ActionSkillChecks;
using Text_Based_Adventure.Engine.InputActions;
using System.Linq;
using Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions;

namespace Text_Based_Adventure.GameObjects
{
    public abstract class GameObject
    {
        public string Name;

        public string DescriptionText;

        public string InspectionText;

        public List<SkillCheckGroup> SkillChecks; // TODO maybe make Item only

        public List<string> SkillCheckNames;

        public GameObject()
        {
            SkillChecks = new List<SkillCheckGroup>();
            SkillCheckNames = new List<string>();
        }

        protected string Readfile(string fileName = "Engine/GameObjects/ObjectText.json")
        {
            return Util.Readfile(fileName);
        }

        public void Describe()
        {
            Util.wl(this.DescriptionText);
        }

        public void Inspect()
        {
            Util.wl(this.InspectionText);
        }

        // Checks to see if the given action can be performed on this game object
        public bool isLocked(Verb action)
        {
            return this.SkillChecks.Where(x => x.IsLocked() && x.getTriggerAction() == action).Count() > 0;
        }

        public SkillCheckGroup getSkillCheckGroup(Verb action)
        {
            return this.SkillChecks.FirstOrDefault(x => x.IsLocked() && x.getTriggerAction() == action);
        }

        public ActionSkillCheck getActionSkillCheck(SkillAction action)
        {
            var lockedGroup = this.SkillChecks.SingleOrDefault(x => x.IsLocked());
            if(lockedGroup != null)
            {
                return lockedGroup.SingleOrDefault(x => x.SkillAction == action);
            }
            return null;
        }
    }
}
