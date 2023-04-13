using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using System.Linq;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal class GameObjectsMenuTree<T> : MenuTree where T : GameObject
    {
        private string VerbText;

        public GameObjectsMenuTree(string verbText, List<T> directObjects)
        {
            Options.AddRange(directObjects.Select(x => new MenuOption(x.Name, x)).ToList());
            VerbText = verbText;
        }

        public override string StartingText => VerbText;
    }
}
