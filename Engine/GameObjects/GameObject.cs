using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions;
using Text_Based_Adventure.Engine.GameObjects.SkillChecks;
using Text_Based_Adventure.Engine.Player;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using Text_Based_Adventure.Engine.UserInputs.Actions;

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

        public List<string> PassiveCheckNames;

        public List<string> Identifiers;

        public GameObject()
        {
            SkillChecks = new List<SkillCheckGroup>();
            PassiveChecks = new List<PassiveSkillCheck>();
            SkillCheckNames = new List<string>();
            Identifiers = new List<string>();
        }

        public void Describe()
        {
            Util.wl(this.DescriptionText);
        }

        // When you inspect something if it has a certain trap on it, you have a chance of detecting said trap.
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

                int result;
                //TODO Combo attribute + skill rolls?
                if (e.Attribute != Attribute.None)
                {
                    result = e.PerformSkillCheck(playerObject, e.Attribute);
                }
                else
                {
                    result = e.PerformSkillCheck(playerObject);
                }

                if (result > e.BestTarget)
                {
                    Util.wl("You dodge the dart");
                }
                else if (result > e.GoodTarget)
                {
                    Util.wl("You kinda dodge the dart");
                }
                else if (result > e.BadTarget)
                {
                    Util.wl("You don't dodge the dart");
                }
                else
                {
                    Util.wl("You messed up big");
                }
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
