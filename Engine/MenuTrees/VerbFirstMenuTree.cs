using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameVerbs;
using Text_Based_Adventure.Engine.GameObjects;
using System.Linq;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal class VerbFirstMenuTree : ActionMenuTree
    {
        public VerbFirstMenuTree()
        {

        }
        public VerbFirstMenuTree(List<GameVerb> availbleActions)
        {
            this.Options.AddRange(availbleActions.Select(x => new MenuOption(x.KeyWord, x)).ToList());
        }
        public override string StartingText => "What do you want to do now?";
    }
}
