using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Based_Adventure.Engine.UserInputs.MenuTrees
{
    public class MenuTree
    {
        protected List<MenuOption> MenuOptions;

        protected string MenuStartText;

        public MenuTree()
        {
            MenuOptions = new List<MenuOption>();
        }

        public bool ParseValidInput(string input, out Int32 result)
        {
            // did they input an int?
            if(int.TryParse(input, out result))
            {
                // positive menu options only for now
                if(result > 0)
                {
                    // was the menu option out of bounds?
                    return result <= MenuOptions.Count;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void StartMenuTree(GameController controller)
        {
            if (String.IsNullOrEmpty(MenuStartText))
            {
                Util.fourthWall("Select one of the following options using using the numbers.");
            }
            else
            {
                Util.fourthWall(MenuStartText);
            }
            
            MenuOptions.ForEach(option =>
            {
                Util.fourthWall($"{MenuOptions.IndexOf(option)+1} : {option.PreSelectionText}");
            });
            Util.fourthWall("type exit to exit.");
            var input = Util.rl();
            while (input != "exit")
            {
                var index = -1;
                if (ParseValidInput(input, out index))
                {
                    var nextOption = MenuOptions[index-1];
                    if (!String.IsNullOrEmpty(nextOption.PostSelectionText))
                    {
                        Util.fourthWall(nextOption.PostSelectionText);
                    }
                    if(nextOption.Action != null)
                    {
                        // TODO need to figure this part out
                        // TODO may want to change the RespondToInput function to take in direct object and not parse scetence
                        nextOption.Action.RespondToInput(controller);
                        break;
                    }
                    if(nextOption.NextMenuTree != null)
                    {
                        nextOption.NextMenuTree.StartMenuTree(controller);
                    }
                }
                else
                {
                    Util.fourthWall("Please select a valid option from the list");
                }
            }
        }

    }
}
