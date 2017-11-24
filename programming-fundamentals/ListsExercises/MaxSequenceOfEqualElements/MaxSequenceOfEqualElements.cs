using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int bestStart = 0;
            int bestLenght = 1;
            int len = 1;
            int start = 0;

            for (int p = 1; p < list.Count; p++)
            {
                if (list[p] == list[p - 1])
                {
                    len++;
                }
                else
                {
                    len = 1;
                    start = p;
                }

                if (len > bestLenght)
                {
                    bestLenght = len;
                    bestStart = start;
                }
            }

            for (int i = 0; i < bestLenght; i++)
            {
                Console.Write(list[bestStart+i]+" ");
            }
            Console.WriteLine();
        }
    }
}
