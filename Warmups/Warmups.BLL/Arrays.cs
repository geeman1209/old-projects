using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            int First6 = numbers[0];
            int Last6 = numbers[numbers.Length - 1];

            if(First6.Equals(6) || Last6.Equals(6))
            {
                return true;
            }

            return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            int First = numbers[0];
            int Last = numbers[numbers.Length - 1];
            if(numbers.Length > 1)
            {
                if(First == Last)
                {
                    return true;
                }
            }

            return false;
        }
        public int[] MakePi(int n)
        {
            var pi = Convert.ToString(Math.PI).Remove(1, 1);
            var piNums = new int[n];

            for (var i = 0; i < n; i++)
            {
                piNums[i] = int.Parse(pi[i].ToString());
            }
            return piNums;

        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            int a1 = a[0];
            int aEnd = a[a.Length - 1];
            int b1 = b[0];
            int bEnd = b[b.Length - 1];

            if(a1 == b1 || aEnd == bEnd)
            {
                return true;
            }

            return false;
        }
        
        public int Sum(int[] numbers)
        {
            int total = 0;

            for(int i =0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }

            return total;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] newArr = { numbers[1], numbers[2], numbers[0] };

            return newArr;
        }
        
        public int[] Reverse(int[] numbers)
        {
            Array.Reverse(numbers);
            return numbers;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int largest = numbers[0];
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[0] < numbers[i])
                {
                    largest = numbers[i];
                }

            }
            for(int i = 0; i<numbers.Length; i++)
            {
                numbers[i] = largest;
            }

            return numbers;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int middleA = a[a.Length - 2];
            int middleB = b[b.Length - 2];
            int [] midArr = { middleA, middleB };
            return midArr;
        }
        
        public bool HasEven(int[] numbers)
        {
            int even;
            for(int i = 0; i < numbers.Length; i++)
            {
                even = numbers[i] % 2;

                if(even == 0)
                {
                    return true;
                }
            }

            return false;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int [] Arr = new int[numbers.Length * 2];

            Arr[Arr.Length - 1] = numbers[numbers.Length - 1];

            return Arr;
        }
        
        public bool Double23(int[] numbers)
        {
            int twoCount = 0;
            int threeCount = 0;

            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == 2)
                {
                    twoCount++;
                }

                if(numbers[i] == 3)
                {
                    threeCount++;
                }
            }
            return twoCount == 2 || threeCount == 2;

        }
        
        public int[] Fix23(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == 2)
                {
                    if(numbers[i + 1] == 3)
                    {
                        numbers[i + 1] = 0;
                    }
                }
            }

            return numbers;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 1)
                {
                    if (numbers[i + 1] == 3)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int[] Make2(int[] a, int[] b)
        {
            int[] arr = new int[2];
            int count = 0;
            int i;

            i = 0;
            while (count < 2 && i < a.Length)
            {
                arr[count] = a[i];
                count++;
                i++;
            }

            i = 0;
            while (count < 2 && i < b.Length)
            {
                arr[count] = b[i];
                count++;
                i++;
            }

            return arr;
        }

    }
}
