using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Text_Based_Adventure
{
    class Util
    {
        public static Random r = new Random();
        public static void wl(string line)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
        }

        public static string rl()
        {
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }

        public static string Readfile(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                return r.ReadToEnd();
            }
        }

        public static T RandomFromList<T>(IEnumerable<T> list) {
            int index = r.Next(list.Count());
            return list.ElementAt(index);
        }
    }
}
