    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace TestNumbers
    {
        class TestNumbers
        {
            static void Main(string[] args)
            {
                int numberN = int.Parse(Console.ReadLine());
                int numberM = int.Parse(Console.ReadLine());
                int sumBoundary = int.Parse(Console.ReadLine());
                int sum = 0;
                int combinationsCount = 0;

                for (int a = numberN; a >= 1; a--)
                {
                    for (int b = 1; b <= numberM; b++)
                    {
                        int number = 3 * (a * b);
                        combinationsCount++;
                        sum += number;
                        if (sum >= sumBoundary)
                        {
                            break;
                        }
                    }
                    if (sum >= sumBoundary)
                    {
                        break;
                    }
                }
                if (sum >= sumBoundary)
                {
                    Console.WriteLine($"{combinationsCount} combinations");
                    Console.WriteLine($"Sum: {sum} >= {sumBoundary}");
                }
                else
                {
                    Console.WriteLine($"{combinationsCount} combinations");
                    Console.WriteLine($"Sum: {sum}");
                }
            }
        }
    }
