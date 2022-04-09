using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Based_Adventure
{
    class Util
    {
        public static void wl(string line)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(line);
        }

        public static string rl()
        {
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }
    }
}
