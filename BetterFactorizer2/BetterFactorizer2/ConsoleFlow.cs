using BetterFactorizer2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizer2
{
    public class ConsoleFlow
    {
        public void Activate()
        {
            ConsoleOutput.DisplayTitle();
            FindFactors f = new FindFactors();
            PerfectNumber pn = new PerfectNumber();
            IsPrimeNumber prime = new IsPrimeNumber();
            int number;

          
           number = ConsoleInput.GetNumberFromUser();
           ConsoleOutput.DisplayFactors();

           f.Factors(number);

            if (pn.IsPerfectNumber(number) == true)
            {
                ConsoleOutput.DisplayPerfect();
            }

            

            if (prime.PrimeNumber(number)== true)
            {
                ConsoleOutput.DisplayPrime();
            }
        
        }
    }
}
