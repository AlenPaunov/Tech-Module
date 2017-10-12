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
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int start = 0;
            int len = 1;
            int bestStart = 0;
            int bestLen = 1;
            for (int position = 1; position < array.Length; position++)
            {
                if (array[position] == array[position - 1])
                {
                    len++;
                    if (len > bestLen)
                    {
                        bestStart = start;
                        bestLen = len;
                    }
                }
                else
                {
                    len = 1;
                    start = position;
                }
            }
            for (int i = 0; i < bestLen; i++)
            {
                Console.Write(array[bestStart + i] + " ");
            }
            Console.WriteLine();
        }
    }
}
