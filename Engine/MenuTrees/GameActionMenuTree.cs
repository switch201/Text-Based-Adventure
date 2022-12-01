using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameActions;
using System.Linq;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal class GameActionMenuTree<T> : MenuTree where T : GameAction
    {
        private List<T> GameActions = new List<T>();
        private string ObjectText;
        public override List<MenuOption> Options => GameActions.Select(x => new MenuOption(x.KeyWord, x)).ToList();

        public override string StartingText => ObjectText;

        public GameActionMenuTree(string startText, List<T> actions)
        {
            ObjectText = startText;
            GameActions.AddRange(actions);
        }
    }
}
