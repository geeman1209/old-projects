using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == true && bSmile == true)
            {
                return true;
            }

            else if (aSmile == false && bSmile == false)
            {
                return true;
            }

            else
                return false;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if ( isVacation == true)
            {
                return true;
            }

            else if (isWeekday == false)
            {
                return true;
            }

            else
                return false;
        }

        public int SumDouble(int a, int b)
        {
            if (a == b)
            {
                return (a + b) * 2;
            }
            else
            {
                return a + b;
            }
        }
        
        public int Diff21(int n)
        {
            if (n > 21)
            {
                return Math.Abs(n - 21) * 2;
            }

            else
            {
                return Math.Abs(21 - n);
            }
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if(isTalking == true && hour < 7 || hour > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10)
            {
                return true;
            }
            else if (a + b == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool NearHundred(int n)
        {
            if( n + 10 >= 100 || n - 10 >= 90)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            if(a < 0 && b > 0 && negative == false)
            {
                return true;
            }
            else if(a > 0 && b <0 && negative == false)
            {
                return true;
            }

            else if(a<0 && b<0 && negative == true)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        
        public string NotString(string s)
        {
            if(s.Length < 3)
            {
                return $"not {s}";
            }
           else if(s.Substring(0,3) != "not")
            {
                return $"not {s}";
            }
            else
            {
                return s;
            }
        }
        
        public string MissingChar(string str, int n)
        {
            char gone = str[n];
            int index1 = str.IndexOf(gone);

            return str.Remove(index1, 1);
        }
        
        public string FrontBack(string str)
        {
            if(str.Length < 1)
            {
                return str;
            }
            string firstLetter = str.Substring(0, 1);
            string lastLetter = str.Substring(str.Length - 1);

            char first = str[0];
            char last = str[str.Length - 1];

            int indexFirst = str.IndexOf(first);
            int indexLast = str.IndexOf(last);

            str = str.Remove(indexFirst, 1);
            str = str.Insert(0, lastLetter);

            str = str.Remove(indexLast);
            str = str.Insert(indexLast, firstLetter);

            return str;


        }
        
        public string Front3(string str)
        {
            string front = "";
            if(str.Length < 3)
            {
                front = str;
            }
            else
            {
                front = str.Substring(0, 3);
            }
            return front + front + front; 
        }
        
        public string BackAround(string str)
        {
            string newCombo = "";
            if(str.Length == 1)
            {
                return str + str + str;
            }
            else
            {
                string lastLetter = str.Substring(str.Length - 1);

                newCombo = $"{lastLetter}{str}{lastLetter}";
            }

            return newCombo;
        }
        
        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }

            else
                return false;
        }
        
        public bool StartHi(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }

            if (str.Length >= 3)
            {
                string goal = "hi ";
            

                if (str.Substring(0, 3) == "hi,")
                {
                    return true;
                }

                else if (str.Substring(0, 3) != goal)
                {
                    return false;
                }

                else if (str.Substring(0, 2) == "hi")
                {
                    return true;
                }

            }  

            return true;
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 > 100 && temp2 < 0)
            {
                return true;
            }
            else if (temp1 < 0 && temp2 > 100)
            {
                return true;
            }
            else
                return false;
        }
        
        public bool Between10and20(int a, int b)
        {
            if (a >= 10 && a <= 20 || b >= 10 && b <= 20)
            {
                return true;
            }

            else
                return false;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            if (a >= 13 && a <= 19 || b >= 13 && b <= 19 || c >= 13 && c <= 19)
            {
                return true;
            }
            else
                return false;
        }
        
        public bool SoAlone(int a, int b)
        {
            if (a >= 13 && a <= 19 && b >= 13 && b <= 19)
            {
                return false;
            }

            else if (a >= 13 && a <= 19 || b >= 13 && b <= 19)
            {
                return true;
            }

            else
                return false;
        }
        
        public string RemoveDel(string str)
        {
            string Found = str.Substring(1, 3);
            string goal = "";
            if (Found == "del")
            {
                goal = str.Remove(1, 3);
                return goal;
            }
            else
                return str;
        }
        
        public bool IxStart(string str)
        {
            string goal = str.Substring(1, 2);
            if(goal == "ix")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public string StartOz(string str)
        {
            if(str.Length < 2)
            {
                return "";
            }
            string OChar = str.Substring(0, 1);
            string ZChar = str.Substring(1, 1);
            string OZ = str.Substring(0, 2);

            if (OZ == "oz")
            {
                return OZ;
            }

            else if (ZChar == "z")
            {
                return ZChar;
            }

            else if (OChar == "o")
            {
                return OChar;
            }

            else
                return str;
        }
        
        public int Max(int a, int b, int c)
        {
            int biggest = 0;
            if (c > b && c > a)
            {
                biggest = c;
            }

            else if (a > b)
            {
                biggest = a;
            }
            else
            {
                biggest = b;
            }
            return biggest;
        }
        
        public int Closer(int a, int b)
        {
            int diffA = 10 - a;
            int diffB = 10 - b;

            if (Math.Abs(diffB) > Math.Abs(diffA))
            {
                return a;
            }

            else if (Math.Abs(diffA) > Math.Abs(diffB))
            {
                return b;
            }

            else
                return 0;
        }
        
        public bool GotE(string str)
        {
            int total = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'e')
                {
                    total++;
                }
            }

            return (total > 0  && total < 4);

        }
        
        public string EndUp(string str)
        {
           if (str.Length < 3)
            {
                return str.ToUpper();
            }

            string last3 = str.Substring(str.Length - 3).ToUpper();
            string beginning = str.Substring(0, str.Length - 3);

            return beginning + last3;
           
        }
        
        public string EveryNth(string str, int n)
        {
            char[] goal = new char[7];
            
            for(int i = 0; i < str.Length; i+=n)
            {
                goal[i] += str[i];
                
            }
            string something = new string(goal);
            return something.Replace("\0", "");
        }
    }
}
