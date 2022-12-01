using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.MenuTrees;

namespace Text_Based_Adventure.Engine.GameActions
{
    internal abstract class GameAction
    {
        public abstract string KeyWord { get; }

        // Should return all Objects that this action can currently be perforrmed on.
        public abstract GameObject? SelectDirectObject(GameController controller);

        // Actor in this context is always the player
        // Try and perofmr this action on the given direct Object
        // Retruns a MenuTreeResult if this Action has another action that follows
        public abstract MenuTreeResult PerformAction(GameController controller, MenuTreeResult incommingAction);

    }
}
