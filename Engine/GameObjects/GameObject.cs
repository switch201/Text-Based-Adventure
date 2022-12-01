using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameActions;
using Text_Based_Adventure.Engine.MenuTrees;

namespace Text_Based_Adventure.Engine.GameObjects

{
    public enum GameObjectType
    {
        Default,
        Item,
        Container,
    }
    //A Game Object is anything that can be seen or otherwise be detected in the game
    internal class GameObject
    {
        public GameObjectType Type;
        public string Name { get; set; }
        public string Description { get; set; }

        public static List<GameAction> AvailbleActions = new List<GameAction>() { new Inspect() };
    }
}
