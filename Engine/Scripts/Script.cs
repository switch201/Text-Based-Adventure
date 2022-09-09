using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure.Engine.Scripts
{
    public abstract class Script
    {
        public abstract void Update(GameObject self);

        public abstract void onMessage(GameObject self, string messageId, string message, GameObject sender);
    }
}
