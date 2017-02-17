using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizer2.BLL
{
   public class IsPrimeNumber
    {
        public bool PrimeNumber(int number)
        {
            int total = 0;
            int[] factors = new int[100];
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    total += i;
                }
            }

            if (total == number + 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
