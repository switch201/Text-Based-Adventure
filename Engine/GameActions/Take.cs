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
    internal class Take : GameAction
    {
        public override string KeyWord => "take";

        public override MenuTreeResult PerformAction(GameController controller, MenuTreeResult incommingAction)
        {
            controller.PlayerController.Player.Inventory.Add(incommingAction.DirectObject as Item);
            if (incommingAction.IndirectObject is Container)
            {
                var container = controller.RoomController.CurrentRoom.Contents.Single(x => incommingAction.IndirectObject == x) as Container;
                container.Inventory.Remove(incommingAction.DirectObject as Item);
                
            }
            else
            {
                controller.RoomController.CurrentRoom.Contents.Remove(incommingAction.DirectObject);
            }
            
            Util.wl($"You Take the {incommingAction.DirectObject.Name} and add it to your inventory.");
            return new MenuTreeResult()
            {
                PlayerAction = this,
                DirectObject = incommingAction.DirectObject,
                HasNext = false,
                ActionSuccess = true
            };
        }

        public override GameObject? SelectDirectObject(GameController controller)
        {
            var itemList = controller.RoomController.CurrentRoom.GetItems();
            if (itemList.Any())
            {
                var tree = new GameObjectsMenuTree<Item>("What do you want to Take", itemList);
                return tree.PickSelection().Selection;
            }
            return null;
        }
    }
}
