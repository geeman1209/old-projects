using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
            return $"<{tag}>{content}</{tag}>";
        }

        public string InsertWord(string container, string word) {
            string firsthalf = container.Substring(0, 2);
            string secondhalf = container.Substring(2, 2);

            return $"{firsthalf}{word}{secondhalf}";
        }

        public string MultipleEndings(string str)
        {
            string last2Chars = str.Substring(str.Length-2);
            return $"{last2Chars}{last2Chars}{last2Chars}";
        }

        public string FirstHalf(string str)
        {
            string FirstHalf = str.Substring(0, (str.Length/2));
            return $"{FirstHalf}";
        }

        public string TrimOne(string str)
        {
             str = str.Remove(0, 1);
             str = str.Remove(str.Length - 1);

            return str;
        }

        public string LongInMiddle(string a, string b)
        {
            if(a.Length > b.Length)
            {
                return $"{b}{a}{b}";
            }
            else
            {
                return $"{a}{b}{a}";
            }
        }

        public string RotateLeft2(string str)
        {
          string str1 = str.Substring(0, 2);
            str = str.Remove(0, 2);
            return $"{str}{str1}";
        }

        public string RotateRight2(string str)
        {
            string str1 = str.Substring(str.Length-2);
            str = str.Remove(str.Length - 2);
            return $"{str1}{str}";
        }

        public string TakeOne(string str, bool fromFront)
        {

            if (fromFront)
            {
                return str.Substring(0,1);
            }

            else
                return str.Substring(str.Length-1);
        }

        public string MiddleTwo(string str)
        {
            string firstChar = str.Substring((str.Length/2) - 1, 2);
            //string secChar = str.Substring();

            return $"{firstChar}";
        }

        public bool EndsWithLy(string str)
        {
            if(str.Length <= 1)
            {
                return false;  
            }

            else 
            {
                string ending = str.Substring(str.Length - 2);
                if (ending == "ly")
                {
                    return true;
                }

                else
                    return false;
            }
        }

        public string FrontAndBack(string str, int n)
        {
            string Front = str.Substring(0, n);
            string Back = str.Substring(str.Length - n);

            return $"{Front}{Back}";
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            string generic = str.Substring(0, 2);           
            if(n > 2)
            {
                return generic;
            }

            string goal = str.Substring(n, 2);
            if (goal.Length < 2)
            {
                return generic;
            }
            
            else
                return goal;
        }

        public bool HasBad(string str)
        {
            if(str.Length < 3)
            {
                return false;
            }
            string badword1 = str.Substring(0, 3);
            string badword2 = str.Substring(1, 3);

            if(badword1.Equals("bad") || badword2.Equals("bad"))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public string AtFirst(string str)
        {

            if(str.Length == 0)
            {
                return "@@";
            }

            else if (str.Length == 1)
            {
                return str+"@";
            }

            else
            {
                string firstTwo = str.Substring(0, 2);
                return firstTwo;
            }
        }

        public string LastChars(string a, string b)
        {
            if(a.Length==0 && b.Length == 0)
            {
                return "@@";
            }
            else if (a.Length == 0)
            {
                return $"@{b.Substring(b.Length - 1)}";
            }
            else if (b.Length == 0)
            {
                return $"{a.Substring(0, 1)}@";
            }

            else
            {
                string first = a.Substring(0, 1);
                string second = b.Substring(b.Length - 1);

                return $"{first}{second}";
            }
        }

        public string ConCat(string a, string b)
        {
            if(a.Length == 0)
            {
                return b;
            }

            else if(b.Length == 0)
            {
                return a;
            }
           else if (a.Substring(a.Length - 1) == b.Substring(0, 1))
            {
                string AltB = b.Remove(0, 1);
                return $"{a}{AltB}";
            }
            else
            {
                return a + b;
            }
        }

        public string SwapLast(string str)
        {
            if(str.Length <= 1)
            {
                return str;
            }
            string lastStr = str.Substring(str.Length - 1);

            string goal = str.Insert(str.Length-2, lastStr);
            return goal = goal.Remove(goal.Length - 1);
        }

        public bool FrontAgain(string str)
        {
            string firstTwo = str.Substring(0, 2);
            string lastTwo = str.Substring(str.Length - 2, 2);

            if (firstTwo == lastTwo)
            {
                return true;
            }

            else
                return false;
        }

        public string MinCat(string a, string b)
        {
            string goal = "";
            int oneLength = a.Length;
            int twoLength = b.Length;
            
            if(oneLength == twoLength)
            {
                return a + b;
            } 

            else if(oneLength > twoLength)
            {
                goal = a.Substring(a.Length - twoLength) + b;
            }

            else if(twoLength > oneLength)
            {
                goal = a + b.Substring(b.Length - oneLength);
            }

            return goal;
        }

        public string TweakFront(string str)
        {
            if(str.Length <= 1)
            {
                return str;
            }
            if (str.Substring(0, 1) == "a" && str.Substring(1, 1) == "b")
            {
                return str;
            }

            else if (str.Substring(0, 1) == "a" && str.Substring(1, 1) != "b")
            {
                string newStr = str.Remove(1, 1);
                return newStr;
            }

            else if (str.Substring(0, 1) != "a" && str.Substring(1, 1) == "b")
            {
                string newStr = str.Remove(0, 1);
                return newStr;
            }

            else
                return str.Remove(0, 2);

        }

        public string StripX(string str)
        {
            if(str.Length < 1)
            {
                return str;
            }
            else if (str == "x")
            {
                return "";
            }
            else if (str.Substring(0, 1).Equals("x") && str.Substring(str.Length - 1).Equals("x"))
            {
                int index1 = str.IndexOf("x");
                int index2 = str.LastIndexOf("x");

                str = str.Remove(index2);
                str = str.Remove(index1, 1);

                return str;

            }

            else if (str.Substring(0, 1).Equals("x"))
            {
                int index1 = str.IndexOf("x");
                str = str.Remove(index1, 1);

                return str;
            }

            else if(str.LastIndexOf("x") == str.Length - 1)
            {
                str = str.Remove(str.Length - 1);
                return str;
            }

            else
                return str;
        }
    }
}
