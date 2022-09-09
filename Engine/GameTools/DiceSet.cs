using Newtonsoft.Json.Linq;
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
        public int Mod;

        public DiceSet(int count, int sides, int Mod)
        {
            this.Count = count;
            this.Sides = sides;
            this.Mod = Mod;
        }

        public int roll()
        {
            int result = 0;
            for(int x = 0; x < Count; x++)
            {
                result += Util.d(Sides);
            }
            return result + Mod;
        }

        public static explicit operator DiceSet(JToken? v)
        {
            return new DiceSet((int)v["Count"], (int)v["Sides"], (int)v["Mod"]);

        }
    }
}
