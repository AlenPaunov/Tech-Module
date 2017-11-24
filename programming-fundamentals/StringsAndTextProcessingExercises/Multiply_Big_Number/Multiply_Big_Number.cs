using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_Big_Number
{
    class Multiply_Big_Number
    {
        static void Main(string[] args)
        {
            char[] number = Console.ReadLine().ToCharArray();
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine("0");
                return;
            }

            StringBuilder builder = new StringBuilder();
            int remainder = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int num = (number[i] - 48) * multiplier + remainder;
                builder.Append(num % 10);

                remainder = num / 10;

                if (i == 0 && remainder > 10)
                {
                    builder.Append(remainder.ToString().Reverse().ToArray().ToString());
                }
                else if (i == 0 && remainder > 0)
                {
                    builder.Append(remainder);
                }
            }

            Console.WriteLine(builder.ToString().TrimEnd('0').Reverse().ToArray());
        }
    }
}
