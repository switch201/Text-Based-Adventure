using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.MenuTrees;
using System.Linq;
using Text_Based_Adventure.Engine.GameActions;

namespace Text_Based_Adventure.Engine.GameVerbs
{
    internal class OpenContainer : GameVerb
    {
        public override string KeyWord => "open container";

        public override void PerformAction(GameController controller, GameAction action)
        {
            throw new NotImplementedException();
        }

        public override GameObject SelectDirectObject(GameController controller)
        {
            var tree = new GameObjectsMenuTree<Container>("What container do you want to open?", new List<Container>() { controller.PlayerController.Player });
            return tree.PickSelection().Selection;
        }
    }
}
