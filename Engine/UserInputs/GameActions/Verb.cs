using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.InputActions
{
    public abstract class Verb
    {
        public abstract string HelpText();
        public abstract List<string> keyWord { get; }

        public abstract int duration { get; }

        public abstract void RespondToInput(GameController controller, List<string> seperatedWords);

    }
}
