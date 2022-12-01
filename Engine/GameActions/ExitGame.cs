using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.MenuTrees;

namespace Text_Based_Adventure.Engine.GameActions
{
    internal class ExitMenu : GameAction
    {
        public override string KeyWord => "Exit Game";

        //public override List<MenuTreeResult> PerformAction<T>(GameController controller, T directObject)
        //{
        //    var results = new List<MenuTreeResult>();
        //    if (directObject.Name == "Yes")
        //    {
        //        controller.CurrentState = GameState.Exit;
        //        return results;
        //    }
        //    return results;
        //}

        public override MenuTreeResult PerformAction(GameController controller, MenuTreeResult incommingAction)
        {
            if (incommingAction.DirectObject.Name == "Yes")
            {
                controller.CurrentState = GameState.Exit;
            }
            return new MenuTreeResult()
            {
                ActionCanceled = incommingAction.DirectObject.Name != "Yes",
                PlayerAction = this,
                HasNext = false
            };
        }

        public override GameObject SelectDirectObject(GameController controller)
        {
            var tree = new GameObjectsMenuTree<GameObject>("Are you Sure?", new List<GameObject>() { new GameObject() { Name = "Yes" }, new GameObject { Name = "No" } });
            return tree.PickSelection().Selection;
        }
    }
}
