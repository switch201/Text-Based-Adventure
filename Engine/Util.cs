using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure
{
    class Util
    {
        public static bool debugMode = true;

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

        public static void log(string text)
        {
            if (debugMode)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(text);
            }
        }

        public static void fourthWall(string text)
        {
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine(text);
        }

        public static string Readfile(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                return r.ReadToEnd();
            }
        }

        public static int d20()
        {
            return r.Next(1, 20);
        }

        public static T RandomFromList<T>(IEnumerable<T> list) {
            int index = r.Next(list.Count());
            return list.ElementAt(index);
        }

        //TODO Items andd stuff too
        public static NPC NameOrIdentifier(List<NPC> npcs, string nameOrIdentifier)
        {
            return npcs
                .Where(x => x.Name.Equals(nameOrIdentifier) || x.Identifiers.Contains(nameOrIdentifier))
                .SingleOrDefault();
        }
    }
}
