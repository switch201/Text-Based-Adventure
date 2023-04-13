using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameActions;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.MenuTrees;

namespace Text_Based_Adventure.Engine.GameVerbs
{
    internal class ExitGame : GameVerb
    {
        public override string KeyWord => "Exit Game";

        public override void PerformAction(GameController controller, GameAction action)
        {
            controller.CurrentState = GameState.Exit;
        }

        public override GameObject SelectDirectObject(GameController controller)
        {
            var tree = new GameObjectsMenuTree<GameObject>("Are you Sure?", new List<GameObject>() { new GameObject() { Name = "Yes" }, new GameObject { Name = "No" } });
            return tree.PickSelection().Selection;
        }
    }
}
