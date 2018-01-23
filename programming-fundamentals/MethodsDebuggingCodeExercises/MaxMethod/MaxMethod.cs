using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMethod
{
    class MaxMethod
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int result = GetMax(GetMax(a, b), c);
            Console.WriteLine(result);
        }

        static int GetMax (int a, int b)
        {
            int maxNumber = a > b ? a : b;

            return maxNumber;
        }
    }
}
