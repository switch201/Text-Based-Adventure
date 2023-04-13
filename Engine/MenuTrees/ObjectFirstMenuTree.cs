using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameVerbs;
using Text_Based_Adventure.Engine.GameObjects;
using System.Linq;

namespace Text_Based_Adventure.Engine.MenuTrees
{
    internal class ObjectFirstMenuTree : ActionMenuTree
    {
        public override string StartingText => "What do you want to interact with?";

        public ObjectFirstMenuTree(List<GameObject> gameObjects)
        {
            this.Options.AddRange(gameObjects.Select(x => new MenuOption(x.Name, x)).ToList());
        }
    }
}
