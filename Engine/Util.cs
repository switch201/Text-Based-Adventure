using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Text_Based_Adventure.Engine.GameObjects;
using Text_Based_Adventure.Engine.GameObjects.Creatures;
using Text_Based_Adventure.GameObjects;

namespace Text_Based_Adventure
{
    class Util
    {
        public static bool debugMode = true;

        public static Random r = new Random();

        public static List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
        public static void wl(string line)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
        }

        public static void writeList(List<string> list)
        {
            foreach (string line in list)
            {
                Util.wl(line);
            }
        }

        public static int readNumber(bool positiveNumber = false)
        {
            bool inputAccepted = false;
            int result = 0;
            while (!inputAccepted)
            {
                try
                {
                    int number = Convert.ToInt32(rl());
                    if (positiveNumber && number < 0)
                    {
                        Util.fourthWall("You have to input a positive number");
                    }
                    else
                    {
                        result = number;
                        inputAccepted = true;
                    }
                }
                catch (Exception e)
                {
                    Util.fourthWall("You have to input a whole number");
                }
            }
            return result;
        }

        public static string rl()
        {
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine().ToLower();
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
            Console.ForegroundColor = ConsoleColor.Cyan;
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
            var roll = r.Next(1, 20);
            Util.log($"D20 Dice Roll {roll}");
            return roll;
        }

        public static int d(int sides)
        {
            var roll = r.Next(1, sides);
            Util.log($"D{sides}, Dice Roll {roll}");
            return roll;
        }

        public static T RandomFromList<T>(IEnumerable<T> list)
        {
            int index = r.Next(list.Count());
            return list.ElementAt(index);
        }

        public static string RandomIdentifier(NPC npc)
        {
            var nameList = npc.Identifiers;
            return Util.RandomFromList(nameList);
        }

        //TODO Items andd stuff too
        public static Creature NameOrIdentifier(List<Creature> npcs, string nameOrIdentifier)
        {
            return npcs
                .Where(x => x.Name.Equals(nameOrIdentifier) || x.Identifiers.Contains(nameOrIdentifier))
                .SingleOrDefault();
        }

        public static int Round(double number)
        {
            return (int)Math.Round(number);
        }

        public static void WriteExceptionSentance(string preText, string itemName)
        {
            if (Util.vowels.Any(x => itemName.StartsWith(x)))
            {
                Util.wl($"{preText} an {itemName}");
            }
            else
            {
                Util.wl($"{preText} a {itemName}");
            }
        }
    }
}
