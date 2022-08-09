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

        public List<ActionSkillCheck> SkillChecks;

        public List<string> SkillCheckNames;

        public GameObject()
        {
            SkillChecks = new List<ActionSkillCheck>();
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
            return this.SkillChecks.Where(x => x.Locked && x.TriggerAction == action).Count() > 0;
        }

        public SkillCheck getLock(SkillAction action)
        {
            return this.SkillChecks.Where(x => x.Locked && x.SkillAction == action).SingleOrDefault();
        }
    }
}
