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
    internal class Take : GameVerb
    {
        public override string KeyWord => "take";

        public override void PerformAction(GameController controller, GameAction action)
        {
            throw new NotImplementedException();
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
