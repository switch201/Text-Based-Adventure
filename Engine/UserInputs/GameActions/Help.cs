using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.UserInputs.GameActions
{
    public class Help : GameAction
    {
        public override List<string> keyWord => new List<string> { "help" };

        public override string HelpText()
        {
            return "Welcome to the help section of the game.\n" +
            "This is where you can get some help.\nThis game's actions have 2 components: the action and the direct object.\n" +
            "The action is the thing you want to do, and the direct object is thing you want to do it to\n" +
            "Type 'help action' to get a list of actions you can do.\n" +
            "You can then type 'help' followed by an action to get more information";
        }

        public override void RespondToInput(GameController controller, List<string> seperatedWords)
        {
            if(seperatedWords.Count() == 1)
            {
                Util.fourthWall(this.HelpText());
            }
            else if (seperatedWords.Last() == "action")
            {
                Util.fourthWall("Here are a list of available actions");
                foreach(string keyWord in controller.userInput.getGameActionWords())
                {
                    Util.fourthWall(keyWord);
                }
                Util.fourthWall("These are all of the actions you can do right now");
            }
            else
            {
                var action = controller.userInput.GetGameAction(seperatedWords.Last());
                if(action != null)
                {
                    Util.fourthWall(action.HelpText());
                }
                else
                {
                    Util.fourthWall("Thats not a valid action, so I can't help you with that.");
                }
            }
        }
    }
}
