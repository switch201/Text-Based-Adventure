using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.InputActions
{
    public  abstract class Verb
    {
        public abstract List<string> keyWord { get; }
    }
}
