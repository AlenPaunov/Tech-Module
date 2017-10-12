﻿using System;
using System.Numerics;

namespace Factorial
{
    class Factorial
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            BigInteger factorial=1;
            for (int i = 1; i <= input; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
    }
}
