//using System;
//using System.Collections.Generic;
//using System.Text;
//using Text_Based_Adventure.Engine.Controllers;
//using Text_Based_Adventure.Engine.GameActions;
//using Text_Based_Adventure.Engine.GameObjects;

//namespace Text_Based_Adventure.Engine.MenuTrees
//{
//    internal class ObjectFirstMenuTree : ActionMenuTree
//    {
//        private List<MenuOption> ObjectOptions = new List<MenuOption>();
//        public override List<MenuOption> Options => ObjectOptions;

//        public override string StartingText => "Select Something to Interact With it.";

//        public override MenuTreeResult StartMenuTree(GameController controller)
//        {
//            Interactable directObject = this.PickSelection().Selection;
//            GameAction action = directObject.SelectAction("");
//            var tree = new GameActionMenuTree<GameAction>()
//            return new MenuTreeResult()
//            {
//                PlayerAction = action,
//                DirectObject = directObject
//            };
//        }

//        public void SetObjectOptions<T>(List<T> gameObjects) where T : GameObject
//        {
//            foreach (var gameObject in gameObjects)
//            {
//                ObjectOptions.Add(new MenuOption(gameObject.Name, gameObject));
//            }
//        }
//    }
//}
