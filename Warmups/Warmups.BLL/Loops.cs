using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            String goal = "";
            for(int i = 0; i < n; i++)
            {
                goal = goal + str;
            }

            return goal;
        }

        public string FrontTimes(string str, int n)
        {
            string Front = str.Substring(0, 3);
            string goal = "";
            if(str.Length < 3)
            {
                for (int i = 0; i < n; i++)
                {
                    goal += str.Substring(str.Length);
                }

            }

            for (int i = 0; i < n; i++)
            {
                goal += Front;
            }

            return goal;
        }

        public int CountXX(string str)
        {
            int total = 0;
            for(int i = str.IndexOf("xx"); i != -1; i = str.IndexOf("xx", i + 1))
            {
                total++;
            }

            return total;
        }

        public bool DoubleX(string str)
        {
            var counter = 0;
            for (var i = 0; i < str.Length - 1; i++)
            {
                if (str[i].Equals('x')) counter++;
                if (str.Substring(i, 2).Equals("xx") && counter < 2) return true;
            }
            return false;
        }

        public string EveryOther(string str)
        {
            if (str.Length <= 2)
            {
                return str.Substring(0, 1);
            }
            char[] goal = new char[10];
        for(int i = 0; i < str.Length; i +=2)
            {
                goal[i] += str[i];
            }
            string result = new string(goal);
            return result.Replace("\0", ""); 
        }

        public string StringSplosion(string str)
        {
            string goal = "";
            for(int i =0; i < str.Length; i++)
            {
                goal += str.Substring(0, i + 1);
            }
            return goal;
        }

        public int CountLast2(string str)
        {
            string last2 = str.Substring(str.Length - 2);
            int count = 0;

            for(int i = 0; i  < str.Length-2; i++)
            {
                string s = str.Substring(i, 2);

                if(s.Equals(last2))
                {
                    count++;
                }
            }

            return count;
        }

        public int Count9(int[] numbers)
        {
            int count = 0;
            for(int i = 0; i <numbers.Length; i++)
            {
                if(numbers[i] == 9)
                {
                    count++;
                }
            }
            return count;
        }

        public bool ArrayFront9(int[] numbers)
        {
            int num1 = numbers[0];
            int num2 = numbers[1];
            int num3 = numbers[2];
            int num4 = numbers[3];

            if(num1 == 9|| num2 == 9 || num3 == 9 || num4 == 9)
            {
                return true;
            }

            return false;
        }

        public bool Array123(int[] numbers)
        {
            for(int i = 0; i < numbers.Length - 1; i++)
            {
                if(numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    return true;
                }
            }

            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int count = 0;
            for(int i = 0; i < a.Length-1 && i < b.Length-1; i++)
            {
                string sub = a.Substring(i, 2);
                string sub2 = b.Substring(i, 2);
                if(sub == sub2)
                {
                    count++;
                }
            }
            return count;
        }

        public string StringX(string str)
        {
            string FirstX = str.Substring(0, 1);
            string LastX = str.Substring(str.Length - 1);

            if(FirstX == "x" && LastX == "x")
            {
                return $"x{str.Replace("x", "")}x";
            }
            
            string goal = "";
            goal = str.Replace("x", "");
           
            return goal;
        }

        public string AltPairs(string str)
        {
            string goal = "";
            for (int i = 0; i < str.Length; i += 4)
            {
                int counter = i + 2;
                int c2 = 0;

                c2 += counter > str.Length ? 1 : 2;
                goal += str.Substring(i, c2);
            }

            return goal;
            
        }

        public string DoNotYak(string str)
        {
            str = str.Replace("yak", "");
            return str;
        }

        public int Array667(int[] numbers)
        {
            int count = 0;
            for(int i = 0; i < numbers.Length -1; i++)
            {
                if(numbers[i] == 6 && numbers[i + 1] == 6)
                {
                    count++;
                }

                else if(numbers[i] == 6 && numbers[i + 1] == 7)
                {
                    count++;
                }
            }

            return count;
        }

        public bool NoTriples(int[] numbers)
        {
            for(int i = 0; i < numbers.Length - 2; i++)
            {
                if(numbers[i].Equals(numbers[i + 1]) && numbers[i + 2].Equals(numbers[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            for(int i = 0; i < numbers.Length - 2; i++)
            {
                int Plus5 = numbers[i] + 5;
                int Minus1 = numbers[i] - 1;
                if(numbers[i +1] == Plus5 && numbers[i + 2] == Minus1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
