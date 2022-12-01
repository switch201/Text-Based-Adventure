using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using System.Linq;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal class GameObjectsMenuTree<T> : MenuTree where T : GameObject
    {
        private List<T> DirectObjects;
        private string VerbText;

        public GameObjectsMenuTree(string verbText, List<T> directObjects)
        {
            DirectObjects = directObjects;
            VerbText = verbText;
        }

        public override List<MenuOption> Options => DirectObjects.Select(x => new MenuOption(x.Name, x)).ToList();

        public override string StartingText => VerbText;
    }
}
