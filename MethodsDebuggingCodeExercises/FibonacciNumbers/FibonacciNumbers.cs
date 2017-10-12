using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    class FibonacciNumbers
    {
        static void Main(string[] args)
        {
            int targetPosition = int.Parse(Console.ReadLine());
            Console.WriteLine(FibonacciOnPosition(targetPosition));
            
        }

        static BigInteger FibonacciOnPosition(int position)
        {
            BigInteger number = 1;
            BigInteger previousNumber = 0;
            for (int i = 0; i < position; i++)
            {
                BigInteger tempNumber = number;
                number += previousNumber;
                previousNumber = tempNumber;
            }
            return number;
        }
    }
}
