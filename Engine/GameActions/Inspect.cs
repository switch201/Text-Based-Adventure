using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using System.Linq;
using Text_Based_Adventure.Engine.MenuTrees;

namespace Text_Based_Adventure.Engine.GameActions
{
    internal class Inspect : GameAction
    {
        public override string KeyWord => "inpsect";

        public override MenuTreeResult PerformAction(GameController controller, MenuTreeResult incommingAction)
        {
            Util.wl(incommingAction.DirectObject.Description);
            if(incommingAction.DirectObject is Item)
            {
                Util.wl($"You could pick this up");
            }
            return new MenuTreeResult()
            {
                PlayerAction = this,
                DirectObject = incommingAction.DirectObject,
                HasNext = false,
                ActionSuccess = true
            };
        }

        public override GameObject SelectDirectObject(GameController controller)
        {
            var gameObjectList = controller.RoomController.CurrentRoom.Contents.ToList();
            gameObjectList.Add(controller.RoomController.CurrentRoom);
            var tree = new GameObjectsMenuTree<GameObject>("What do you want to inspect", gameObjectList);
            return tree.PickSelection().Selection;
        }
    }
}
