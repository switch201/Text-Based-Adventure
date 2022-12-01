using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using System.Linq;
using Text_Based_Adventure.Engine.MenuTrees;
using Text_Based_Adventure.Engine.GameObjects.Rooms;

namespace Text_Based_Adventure.Engine.GameActions
{
    internal class ChangeRoom : GameAction
    {
        public override string KeyWord => "go";

        public override MenuTreeResult PerformAction(GameController controller, MenuTreeResult incommingAction) 
        {
            var newRoom = incommingAction.DirectObject as Room;
            Util.wl($"You Exit the {controller.RoomController.CurrentRoom.Name} and Enter the {newRoom.Name}");
            controller.RoomController.SetCurrentRoom(newRoom);
            return new MenuTreeResult()
            {
                PlayerAction = this,
                DirectObject = newRoom,
                HasNext = false,
                ActionSuccess = true
            };
        }

        public override GameObject SelectDirectObject(GameController controller)
        {
            var tree = new GameObjectsMenuTree<Room>("Where do you want to go?", controller.RoomController.CurrentRoom.Exits.Select(x => x.EnteringRoom).ToList());
            return tree.PickSelection().Selection;
        }
    }
}
