using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Multiplier
{
    class Character_Multiplier
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int totalSum = CharsMultiplier(input);

            Console.WriteLine(totalSum);
        }

        private static int CharsMultiplier(string[] input)
        {
            char[] first = input[0].ToCharArray();
            char[] second = input[1].ToCharArray();

            int minLen = Math.Min(first.Length, second.Length);

            int totalSum = 0;
            for (int i = 0; i < minLen; i++)
            {
                totalSum += first[i] * second[i];
            }
            totalSum += first.Length > second.Length ? first.Skip(minLen).Sum(x => (int)x) : second.Skip(minLen).Sum(x => (int)x);
            return totalSum;
        }
    }
}
