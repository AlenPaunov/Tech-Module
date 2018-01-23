using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveDifferentNumbers
{
    class FiveDifferentNumbers
    {
        static void Main(string[] args)
        {
            int numberA = int.Parse(Console.ReadLine());
            int numberB = int.Parse(Console.ReadLine());

            if (numberB - numberA < 5)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int a = numberA; a <= numberB - 4; a++)
                {
                    for (int b = numberA + 1; b <= numberB - 3; b++)
                    {
                        for (int c = numberA + 2; c <= numberB - 2; c++)
                        {
                            for (int d = numberA + 3; d <= numberB - 1; d++)
                            {
                                for (int e = numberA + 4; e <= numberB; e++)
                                {
                                    if (a < b && b < c && c < d && d < e)
                                    {
                                        Console.WriteLine($"{a} {b} {c} {d} {e}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
