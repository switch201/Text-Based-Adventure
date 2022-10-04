using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.UserInputs.Actions;

namespace Text_Based_Adventure.Engine.UserInputs.MenuTrees
{
    public class MenuOption
    {
        // If the selection of this MenuOption results in a new set of options
        public MenuTree? NextMenuTree;

        // If the selection of this MenuOption results in the player performing a Verb
        public Verb? Action;

        // The Text that displays before you pick this option
        public string PreSelectionText;

        // The Text that displays after this option is selected
        public string? PostSelectionText;


    }
}
