using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizer2.BLL
{

    public class FindFactors
    {
        public int [] Factors(int number)
        {
            int[] factors = new int[100];
            for (int i = 1; i<=number; i++)
            {
                if (number%i == 0)
                {
                    factors[i] += i;
                    Console.WriteLine(" " + factors[i]);
                }
            }

            return factors;
        }
    
    }

}
