using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameActions;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal class OverWorldMenuTree : VerbFirstMenuTree
    {
        public override List<MenuOption> Options => new List<MenuOption>()
        {
            new MenuOption("go", new ChangeRoom()),
            new MenuOption("inspect", new Inspect()),
            new MenuOption("interact", new Interact()),
            new MenuOption("exit", new ExitMenu())
            //new MenuOption("take", new Take()),
            //new MenuOption("Open Container", new OpenContainer()),
            //new MenuOption("exit", new ExitGame())
        };
    }
}
