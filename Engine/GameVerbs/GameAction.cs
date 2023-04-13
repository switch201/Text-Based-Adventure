using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameActions;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.MenuTrees;

namespace Text_Based_Adventure.Engine.GameVerbs
{
    internal abstract class GameVerb
    {
        public abstract string KeyWord { get; }

        // Should return all Objects that this action can currently be perforrmed on.
        public abstract GameObject? SelectDirectObject(GameController controller);

        public abstract void PerformAction(GameController controller, GameAction action);

        //public abstract int ActionTime { get; }

        // Actor in this context is always the player
        // Try and perofmr this action on the given direct Object
        // Retruns a MenuTreeResult if this Action has another action that follows
        //public abstract MenuTreeResult PerformAction(GameController controller, MenuTreeResult incommingAction);

    }
}
