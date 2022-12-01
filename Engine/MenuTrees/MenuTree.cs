using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameActions;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal abstract class MenuTree
    {
        public abstract List<MenuOption> Options { get; }

        public abstract string StartingText { get; }

        public MenuOption PickSelection()
        {
            var options = this.Options;
            Util.fourthWall(StartingText);
            foreach (var (option, index) in Util.WithIndex(options))
            {
                Util.fourthWall($"{index+1}: {option.SelectionText}");
            }
            string userInput = Util.rl();
            int numberSelection = -1;
            if (int.TryParse(userInput, out numberSelection))
            {
                if(0 < numberSelection && numberSelection <= options.Count)
                {
                     return options[numberSelection-1];
                }
                else
                {
                    Util.fourthWall("You have to pick from the options");
                    return this.PickSelection();
                }
            }
            else
            {
                Util.fourthWall("Only type numbers.");
                return this.PickSelection();
            }

        }
    }
}
