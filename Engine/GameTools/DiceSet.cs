using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure.Engine.GameTools
{
    // Represents a set of dice ex: 3d7
    public class DiceSet
    {
        public int Count;
        public int Sides;

        public int roll()
        {
            int result = 0;
            for(int x = 0; x < Count; x++)
            {
                result += Util.d(Sides);
            }
            return result;
        }
    }
}
