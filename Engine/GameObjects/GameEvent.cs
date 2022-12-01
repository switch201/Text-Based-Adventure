using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects.Actors;

namespace Text_Based_Adventure.Engine.GameObjects
{
    // A GameEvent is broadcast whenever an Actor does something.
    internal class GameEvent
    {
        Actor Actor;
        GameObject DirectObject;
    }
}
