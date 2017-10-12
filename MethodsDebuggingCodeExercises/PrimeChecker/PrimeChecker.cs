using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChecker
{
    class PrimeChecker
    {
        static void Main(string[] args)
        {
            ulong numberToCheck = ulong.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(numberToCheck));
        }

        static bool IsPrime(ulong n)
        {
            ulong i = 2;

            if (n % i == 0)
            {
                return false;
            }

            for (i = 1; i <= n - 2; i+=2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            if (i == n)
            {
                return true;
            }
            return false;
        }
    }
}
