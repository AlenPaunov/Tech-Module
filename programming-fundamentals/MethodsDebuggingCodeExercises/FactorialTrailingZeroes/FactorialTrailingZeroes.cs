using System;
using System.Numerics;

namespace FactorialTrailingZeroes
{
    class FactorialTrailingZeroes
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            for (int i = 1; i <= input; i++)
            {
                factorial *= i;
            }
            string factorialArray = factorial.ToString();
            int zeroesCount = 0;
            for (int i = factorialArray.Length-1; i >= 0; i--)
            {
                if (factorialArray[i]=='0')
                {
                    zeroesCount++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(zeroesCount);
        }
    }
}
