using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using System.Linq;
using Text_Based_Adventure.Engine.MenuTrees;
using Text_Based_Adventure.Engine.GameActions;

namespace Text_Based_Adventure.Engine.GameVerbs
{
    internal class Inspect : GameVerb
    {
        public override string KeyWord => "inpsect";

        public override void PerformAction(GameController controller, GameAction action)
        {
            Util.wl(action.DirectObject.Description);
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
