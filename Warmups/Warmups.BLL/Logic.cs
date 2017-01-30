using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if(isWeekend == true)
            {
                return true;
            }

            if(isWeekend == false)
            {
                if(cigars > 40 && cigars < 60)
                {
                    return true;
                }
            }

            return false;
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if(yourStyle >= 8 || dateStyle >= 8)
            {
                return 2;
            }

            else if(yourStyle <= 2 || dateStyle <= 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (isSummer == false)
            {
                if (temp >= 60 && temp <= 90)
                {
                    return true;
                }
            }

            else if (isSummer == true)
            {
                if (temp >= 60 && temp <= 100)
                {
                    return true;
                }
            }
                return false;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if(isBirthday == false)
            {
                if(speed <= 60)
                {
                    return 0;
                }

                else if(speed >= 61 && speed <= 80)
                {
                    return 1;
                }

                else if(speed >= 81)
                {
                    return 2;
                }
            }

            if(isBirthday == true)
            {
                if (speed <= 65)
                {
                    return 0;
                }

                else if (speed >= 66 && speed <= 85)
                {
                    return 1;
                }

                else if (speed >= 86)
                {
                    return 2;
                }
            }

            return 0;
        }
        
        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if(sum >= 10 && sum <= 19)
            {
                return 20;
            }

            return sum;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            if(vacation == false)
            {
                if(day == 0 || day == 6)
                {
                    return "10:00";
                }
                else
                {
                    return "7:00";
                }
            }

            if (vacation == true)
            {
                if (day == 0 || day == 6)
                {
                    return "off";
                }
                else
                {
                    return "10:00";
                }
            }

            return "7:00";
        }
        
        public bool LoveSix(int a, int b)
        {
            int sum = a + b;
            int difference = Math.Abs(a - b);

            if(sum == 6 || a == 6 || b == 6 || difference == 6)
            {
                return true;
            }

            return false;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if(outsideMode == false)
            {
                if(n >= 1 && n <= 10)
                {
                    return true;
                }
            }
            if (outsideMode == true)
            {
                if(n <= 1 || n >= 10)
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool SpecialEleven(int n)
        {
            int multiple11 = (n % 11);
            int multPlusOne = multiple11 + 1;
            int multPlusTwo = multiple11 + 2;

            if(multiple11 == 0 || multPlusOne == 2)
            {
                return true;
            }

            return false;
        }
        
        public bool Mod20(int n)
        {
            int multiple20 = (n % 20);
            int multPlusOne = multiple20 + 1;
            int multPlusTwo = multiple20 + 2;

            if(multPlusOne == 2 || multPlusTwo == 4)
            {
                return true;
            }

            return false;
        }
        
        public bool Mod35(int n)
        {
            if (n%3 == 0 && n%5 == 0)
            {
                return false;
            }

            else if(n % 3 == 0)
            {
                return true;
            }

            else if(n % 5 == 0)
            {
                return true;
            }

            return false;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if(isAsleep == true)
            {
                return false;
            }

            else if(isMorning == true && isMom == true)
            {
                return true;
            }

            else if (isMorning == true)
            {
                return false;
            }

            return true;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            int sum1 = a + b;
            int sum2 = b + c;

            if(sum1 == c || sum2 == a)
            {
                return true;
            }

            return false;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if(bOk == true)
            {
                if(c > a && c > b)
                {
                    return true;
                }
            }

            if(bOk == false)
            {
                if(b>a && c > b)
                {
                    return true;
                }

            }

            return false;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if(equalOk == true)
            {
                if(a == b || b == c)
                {
                    return true;
                }
            }

            if(equalOk == false)
            {
                if(a < b && b < c)
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            int remainderA = a % 10;
            int remainderB = b % 10;
            int remainderC = c % 10;

            if(remainderA == remainderC)
            {
                return true;
            }

            else if(remainderA == remainderB)
            {
                return false;
            }

            return false;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int sum = die1 + die2;

            if(noDoubles == true)
            {
                if( die1 == die2)
                {
                    return sum + 1;
                }
            }

            if(noDoubles == false)
            {
                return sum;
            }

            return sum;
        }

    }
}
