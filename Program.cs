//#define DEBUG
#undef DEBUG

using System;
using Advent_Of_Code_2020.Days;
using System.IO;

namespace Advent_Of_Code_2020
{
    class Program
    {
        private static bool Debug = false;
        static void Main(string[] args)
        {
#if (DEBUG)
            Console.WriteLine("Debug is Enabled");
            Debug = True;
#endif

            foreach (Day d in Day.GetAllDays(Debug))
            {
                try
                {
                    Console.WriteLine(d.Solution);
                }
                catch(FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
