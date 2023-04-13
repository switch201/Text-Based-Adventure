using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.Controllers;
using Text_Based_Adventure.Engine.GameActions;
using Text_Based_Adventure.Engine.GameObjects;

namespace Text_Based_Adventure.Engine.GameVerbs
{
    internal class Attack : GameVerb
    {
        public override string KeyWord => throw new NotImplementedException();

        public override void PerformAction(GameController controller, GameAction action)
        {
            throw new NotImplementedException();
        }

        public override GameObject? SelectDirectObject(GameController controller)
        {
            throw new NotImplementedException();
        }
    }
}
