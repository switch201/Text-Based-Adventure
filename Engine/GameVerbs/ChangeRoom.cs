using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using System.Linq;
using Text_Based_Adventure.Engine.MenuTrees;
using Text_Based_Adventure.Engine.GameObjects.Rooms;
using Text_Based_Adventure.Engine.GameActions;

namespace Text_Based_Adventure.Engine.GameVerbs
{
    internal class ChangeRoom : GameVerb
    {
        public override string KeyWord => "go";

        public override void PerformAction(GameController controller, GameAction action)
        {
            controller.RoomController.SetCurrentRoom((Room)action.DirectObject);
        }

        public override GameObject SelectDirectObject(GameController controller)
        {
            var tree = new GameObjectsMenuTree<Room>("Where do you want to go?", controller.RoomController.CurrentRoom.Exits.Select(x => x.EnteringRoom).ToList());
            return tree.PickSelection(true).Selection;
        }
    }
}
