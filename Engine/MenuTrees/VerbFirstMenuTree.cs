using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameActions;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal abstract class VerbFirstMenuTree : ActionMenuTree
    {
        public override MenuTreeResult StartMenuTree(GameController controller)
        {
            GameAction action = PickSelection().Selection;
            dynamic directObject = action.SelectDirectObject(controller);
            return new MenuTreeResult()
            {
                PlayerAction = action,
                DirectObject = directObject
            };
        }
        public override string StartingText => "What do you want to do now?";
    }
}
