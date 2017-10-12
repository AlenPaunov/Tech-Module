using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterNumber
{
    class MasterNumber
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int divisibleByDigit = 7;
            for (int i = 16; i <= num; i++)
            {
                if (IsPalindrome(i.ToString()) == true &&
                    ContainsEvenDigit(i) == true &&
                    SumOfDigits(i) % divisibleByDigit == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        public static bool IsPalindrome(string num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] != num[num.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ContainsEvenDigit(int num)
        {
            while (num != 0)
            {
                if ((num % 10) % 2 == 0)
                {
                    return true;
                }
                num /= 10;
            }
            return false;
        }

        public static int SumOfDigits(int num)
        {
            int sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
    }
}

