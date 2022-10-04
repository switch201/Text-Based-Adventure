using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes;
using Text_Based_Adventure.Engine.Player;
using Text_Based_Adventure.Engine.UserInputs.Actions;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;

namespace Text_Based_Adventure.Engine.GameObjects.SkillChecks
{
    public class SkillCheck
    {
        public string Name;

        public bool Broken; // When true skill check can no longer be attempted or occurrrrr

        // how hard is this thing?
        public int BestTarget;
        public int GoodTarget;
        public int BadTarget;

        public Attribute Attribute; // The Attributes checks you need to pass for this skill check (can be a combo)
        public Skill Skill; // The skill need to pass the skill check.

        // The action that cause the skill check to happen
        // The thing you are trying to do  For passive skills it happens automatically
        // For action skills its the thing you are trying to do.
        public Verb TriggerAction;

        public string TriggerWord; // looks up Trigger action durring Factory Creation

        public int PerformSkillCheck(PlayerObject player, Attribute attribute)
        {
            int attempt = player.getFullMod(attribute) + Util.d20();
            Util.log($"Attribute Check for {attribute} need a {GoodTarget} or above");
            Util.log($"Player Total {attempt}");
            return attempt;
        }

        // SKill is implied
        //TODO check for hidden vs announced?
        public int PerformSkillCheck(PlayerObject player) 
        {
            int attempt = (player.hasSkill(Skill) ? player.ProficiencyBonus : 0) + Util.d20();
            Util.log($"Attribute Check for {Skill} need a {GoodTarget} or above");
            Util.log($"Player Total {attempt}");
            return attempt;
        }
    }
}
