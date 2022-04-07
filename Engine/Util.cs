using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure
{
    class Util
    {
        public static void wl(string line)
        {
            Console.WriteLine(line);
        }

        public static string rl()
        {
            return Console.ReadLine();
        }
    }
}
