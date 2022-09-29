using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.InputActions;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.Scripts
{
    public class DefaultScript : Script
    {
        public override void onMessage(GameObject self, string messageId, string message, GameObject sender)
        {
            throw new NotImplementedException();
        }

        public override void React(GameObject self, Verb Action)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameObject self)
        {
            throw new NotImplementedException();
        }
    }
}
