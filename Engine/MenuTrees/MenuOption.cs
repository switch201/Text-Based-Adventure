using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameActions;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal class MenuOption
    {
        public MenuOption(string selectionText, GameAction action)
        {
            SelectionText = selectionText;
            Selection = action;
        }

        public MenuOption(string selectionText, GameObject gameObject)
        {
            SelectionText = selectionText;
            Selection = gameObject;
        }
        public string SelectionText { get; set; }
        public dynamic Selection { get; set; }
    }
}
