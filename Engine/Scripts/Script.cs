using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.Scripts
{
    public abstract class Script
    {
        ActionList actionList;
        public abstract void Execute();
    }
}
