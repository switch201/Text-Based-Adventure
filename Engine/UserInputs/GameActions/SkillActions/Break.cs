﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;
using Text_Based_Adventure.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.SkillChecks.ActionSkillChecks;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions.SkillActions
{
    public class Break : SkillAction
    {
        public override List<string> keyWord => new List<string>() { "break" };

        public override int duration => 1;

        public override string HelpText()
        {
            return "Is something in your way and just asking... BEGGING to be smashed into teeny tiny pieces?" +
                "type 'break <itemName>' to try to over come something like a locked door or chest.";
        }


        // TODO I CAN MAKE THIS WHOLE METHOD ONE LEVEL HIGHER SORRY FOR THE CAPS
        

        public override void BadOutcome(GameController? gameController, GameObject? gameObject)
        {
            Util.wl($"You give the {gameObject.Name} a hardy smack but it seems unsaved");
        }

        public override void BestOutcome(GameController? gameController, GameObject? gameObject)
        {
            this.GoodOutcome(gameController, gameObject);
        }

        public override void GoodOutcome(GameController? gameController, GameObject? gameObject)
        {
            Util.wl($"You are able to break the {gameObject.Name}");
            ((ActionSkillCheck)gameObject.getLock(this)).Locked = false;
        }

        public override void WorstOutcome(GameController? gameController, GameObject? gameObject)
        {
            Util.wl($"You messed up so bad I can describe it {gameObject.Name}");
            ((ActionSkillCheck)gameObject.getLock(this)).Broken = true;
        }
    }
}
