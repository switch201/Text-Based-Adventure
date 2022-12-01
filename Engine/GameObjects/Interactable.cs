using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameActions;

namespace Text_Based_Adventure.Engine.GameObjects
{
    internal class Interactable : GameObject
    {
        public List<GameAction> Interactions = new List<GameAction>();
    }
}
