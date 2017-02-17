using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizer2.BLL
{
    public class PerfectNumber
    {
        public bool IsPerfectNumber(int number)
        {
            int total = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    total += i;
                }
            }


            if (total == number)
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
