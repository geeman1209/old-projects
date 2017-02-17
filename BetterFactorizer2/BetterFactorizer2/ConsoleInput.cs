using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizer2
{
    public class ConsoleInput
    {
        public static int GetNumberFromUser()
        {
            Console.Clear();
            int number;
            while (true)
            {
                Console.Write("What number would you like to factor? ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Please try again, you did not enter a number.");
                }
            }      
        }
    }
}
