using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.GameObjects.Publishers
{
    internal class Publisher
    {
        public event EventHandler<GameEvent> OnChange = delegate { };
    }
}
