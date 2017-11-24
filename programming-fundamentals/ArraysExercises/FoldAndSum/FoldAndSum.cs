using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var len = numbers.Length / 4;

            FoldAndSumArray(numbers, len, out int[] bot, out int[] top);
            PrintArraySum(len, bot, top);
        }

        private static void PrintArraySum(int len, int[] bot, int[] top)
        {
            for (int i = 0; i < len * 2; i++)
            {

                Console.Write("{0} ", top[i] + bot[i]);
            }
            Console.WriteLine();
        }

        private static void FoldAndSumArray(int[] numbers, int len, out int[] bot, out int[] top)
        {
            int[] firstTop = new int[len];
            int[] secondTop = new int[len];
            bot = new int[len * 2];
            top = new int[len * 2];
            Array.Copy(numbers, firstTop, len);
            Array.Copy(numbers, len * 3, secondTop, 0, len);
            Array.Copy(numbers, len, bot, 0, len * 2);

            Array.Reverse(firstTop);
            Array.Reverse(secondTop);

            Array.Copy(firstTop, top, firstTop.Length);
            Array.Copy(secondTop, 0, top, firstTop.Length, secondTop.Length);
        }
    }
}
