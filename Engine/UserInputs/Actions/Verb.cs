using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.UserInputs.Actions
{
    public abstract class Verb
    {
        public abstract string HelpText();
        public abstract List<string> keyWord { get; }

        public abstract int duration { get; }

        public string directObjectString;

        public abstract void RespondToInput(GameController controller, List<string> seperatedWords);

        public abstract void RespondToInput(GameController controller, string direcObject);

        public abstract void RespondToInput(GameController controller);

    }
}
