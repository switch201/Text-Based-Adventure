using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Attribute = Text_Based_Adventure.Engine.GameObjects.Creatures.Attributes.Attribute;

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

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            string itemName = seperatedWords.Last();
            var item = controller.roomController.currentRoom.getItem(itemName);
            if(item == null)
            {
                Util.wl("You can't break that"); //TODO make this generic
            }
            else
            {
                var gameLock = item.getLock(this);
                if(gameLock == null)
                {
                    Util.wl($"{item.Name} can't be broken like that");
                }
                else
                {
                    // TODO THIS IS WHERE THE PLAYER DOES THE SKILL CHECK
                    int result = gameLock.PerformSkillCheck(controller.playerController.player, Attribute.Strength);
                }
            }
        }

        public override void BadOutcome(GameController? gameController)
        {
            throw new NotImplementedException();
        }

        public override void BestOutcome(GameController? gameController)
        {
            throw new NotImplementedException();
        }

        public override void GoodOutcome(GameController? gameController)
        {
            throw new NotImplementedException();
        }

        public override void WorstOutcome(GameController? gameController)
        {
            throw new NotImplementedException();
        }
    }
}
