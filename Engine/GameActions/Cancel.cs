using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.MenuTrees;

namespace Text_Based_Adventure.Engine.GameActions
{
    internal class Cancel : GameAction
    {
        public override string KeyWord => throw new NotImplementedException();

        public override MenuTreeResult PerformAction(GameController controller, MenuTreeResult incommingAction)
        {
            incommingAction.ActionCanceled = true;
            return incommingAction;
        }

        public override GameObject? SelectDirectObject(GameController controller)
        {
            throw new NotImplementedException();
        }
    }
}
