using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using System.Linq;
using Text_Based_Adventure.Engine.MenuTrees;

namespace Text_Based_Adventure.Engine.GameActions
{
    internal class Interact : GameAction
    {
        public override string KeyWord => "interact";

        public override MenuTreeResult PerformAction(GameController controller, MenuTreeResult menuTreeResult)
        {
            var interactable = menuTreeResult.DirectObject as Interactable;
            var tree = new GameActionMenuTree<GameAction>($"How do you want to interact with {interactable.Name}?", interactable.Interactions);
            var selection = tree.PickSelection().Selection;
            return new MenuTreeResult()
            {
                PlayerAction = selection,
                DirectObject = interactable,
                IndirectObject = null,
                HasNext = true,
            };
        }

        public override GameObject? SelectDirectObject(GameController controller)
        {
            var gameObjectList = controller.RoomController.CurrentRoom.GetInteractables();
            var tree = new GameObjectsMenuTree<Interactable>("What do you want to interact with", gameObjectList);
            return tree.PickSelection().Selection;
        }
    }
}
