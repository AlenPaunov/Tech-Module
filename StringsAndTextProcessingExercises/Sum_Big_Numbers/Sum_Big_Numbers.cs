using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Big_Numbers
{
    class Sum_Big_Numbers
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            if (firstNumber.Length > secondNumber.Length)
            {
                secondNumber = secondNumber.PadLeft(firstNumber.Length, '0');
            }
            else
            {
                firstNumber = firstNumber.PadLeft(secondNumber.Length, '0');
            }

            StringBuilder builder = new StringBuilder();
            int remainder = 0;

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int number = firstNumber[i] - 48 + secondNumber[i] - 48 + remainder;
                builder.Append(number % 10);
                remainder = number / 10;
            }
            if (remainder > 0)
            {
                builder.Append(remainder);
            }
            Console.WriteLine(new string(builder.ToString().TrimEnd('0').Reverse().ToArray()));
        }
    }
}
