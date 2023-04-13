using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameVerbs;
using System.Linq;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal class GameActionMenuTree<T> : MenuTree where T : GameVerb
    {
        private string ObjectText;
        public override string StartingText => ObjectText;

        public GameActionMenuTree(string startText, List<T> actions)
        {
            ObjectText = startText;
            Options.AddRange(actions.Select(x => new MenuOption(x.KeyWord, x)).ToList());
        }
    }
}
