using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Text_Based_Adventure.Engine.InputActions;
using System.Linq;
using Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions;
using Text_Based_Adventure.Engine.GameObjects.SkillChecks;
using Text_Based_Adventure.Engine.Player;

namespace Text_Based_Adventure.GameObjects
{
    public abstract class GameObject
    {
        public string Name;

        public string DescriptionText;

        public string InspectionText;

        public List<SkillCheckGroup> SkillChecks; // TODO maybe make Item only

        public List<PassiveSkillCheck> PassiveChecks;

        public List<string> SkillCheckNames;

        public List<string> Identifiers;

        public GameObject()
        {
            SkillChecks = new List<SkillCheckGroup>();
            PassiveChecks = new List<PassiveSkillCheck>();
            SkillCheckNames = new List<string>();
            Identifiers = new List<string>();
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
            return this.SkillChecks.Any(x => x.IsLocked() && x.getTriggerAction() == action);
        }

        public bool hasEvent(Verb action)
        {
            return this.PassiveChecks.Any(x => x.TriggerAction == action && !x.Broken);
        }

        public void TriggerEvent(Verb action, PlayerObject playerObject)
        {
            var events = this.PassiveChecks.Where(x => x.TriggerAction == action && !x.Broken).ToList();
            foreach(var e in events)
            {
                var result = e.PerformSkillCheck(playerObject);
            }
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
