using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersInReversedOrder
{
    class NumbersInReversedOrder
    {
        static void Main(string[] args)
        {
            char[] number = Console.ReadLine().ToArray();
            Console.WriteLine(ReverseOrder(number));
        }

        private static string ReverseOrder(char[] number)
        {
            string reversed = new string (number.Reverse().ToArray());
            return reversed;
        }
    }
}
