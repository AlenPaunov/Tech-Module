using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSums
{
    class EqualSums
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            if (array.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array.Sum() - array[i] - array.Skip(i + 1).Sum() == array.Skip(i + 1).Sum())
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
