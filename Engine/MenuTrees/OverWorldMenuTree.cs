using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameVerbs;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal class OverWorldMenuTree : MenuTree
    {

        public OverWorldMenuTree()
        {
            Options.AddRange(new List<MenuOption>()
            {
                new MenuOption("go", new ChangeRoom()),
                new MenuOption("inspect", new Inspect()),
                new MenuOption("take", new Take()),
                new MenuOption("talk to", new TalkTo()),
                new MenuOption("exit", new ExitGame())
                //new MenuOption("take", new Take()),
                //new MenuOption("Open Container", new OpenContainer()),
                //new MenuOption("exit", new ExitGame())
            });
        }

        public override string StartingText => "What do you want to do now";
    }
}
