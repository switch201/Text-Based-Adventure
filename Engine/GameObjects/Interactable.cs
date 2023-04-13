using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameVerbs;

namespace Text_Based_Adventure.Engine.GameObjects
{
    internal class Interactable : GameObject
    {
        public List<GameVerb> Interactions = new List<GameVerb>();
    }
}
