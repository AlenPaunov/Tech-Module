using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    class MostFrequentNumber
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int countMax = -1;
            int elementMax = -1;

            foreach (int item in array)
            {
                int count = 0;
                for (int position = 0; position < array.Length; position++)
                {
                    if (array[position] == item)
                    {
                        count++;
                    }
                    if (count > countMax)
                    {
                        countMax = count;
                        elementMax = item;
                    }
                }
            }
            Console.WriteLine(elementMax);
        }
    }
}
