using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.MenuTrees;
using System.Linq;

namespace Text_Based_Adventure.Engine.GameActions
{
    internal class OpenContainer : GameAction
    {
        public override string KeyWord => "open container";

        public override MenuTreeResult PerformAction(GameController controller, MenuTreeResult incommingAction)
        {
            var container = incommingAction.DirectObject as Container;
            var contentsTree = new GameObjectsMenuTree<Item>($"This is what is in the {container.Name}?", container.Inventory);
            var item = contentsTree.PickSelection().Selection as Item;
            var actionsTree = new GameActionMenuTree<GameAction>($"What do you want to do with ${item.Name}", item.Interactions);
            return new MenuTreeResult()
            {
                PlayerAction = actionsTree.PickSelection().Selection,
                DirectObject = item,
                IndirectObject = container,
                HasNext = true,
            };
        }

        public override GameObject SelectDirectObject(GameController controller)
        {
            var tree = new GameObjectsMenuTree<Container>("What container do you want to open?", new List<Container>() { controller.PlayerController.Player });
            return tree.PickSelection().Selection;
        }
    }
}
