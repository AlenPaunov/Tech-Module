using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairsByDifference
{
    class PairsByDifference
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());
            int pairsCount = 0;

            for (int a = array.Length-1; a >= 0; a--)
            {
                for (int b = a; b >= 0; b--)
                {
                    if (array[a]-array[b]==diff||array[b]-array[a]==diff)
                    {
                        pairsCount++;
                    }
                }
            }
            Console.WriteLine(pairsCount);
        }
    }
}
