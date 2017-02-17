using BetterFactorizer2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizer2
{
    public class ConsoleOutput
    {

        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Better Testable, Factorizer!\n\n");
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey();
        }

        public static void DisplayFactors()
        {
            Console.WriteLine("Here are your factors: ");
        }

        public static void DisplayPrime()
        {
            Console.WriteLine("Yes, the number is a prime");
        }

        public static void DisplayPerfect()
        {
            Console.WriteLine("The number is perfect, good job!");
        }
    }
}
