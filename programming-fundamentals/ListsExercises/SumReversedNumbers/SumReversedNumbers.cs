using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumReversedNumbers
{
    class SumReversedNumbers
    {
        static void Main(string[] args)
        {
            int[] numbersArray = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();
            for (int x = 0; x < numbersArray.Length; x++)
            {
                int [] reversedNumber = numbersArray[x].ToString().Select(digit => int.Parse(digit.ToString())).Reverse().ToArray();
                numbersArray[x] = int.Parse(string.Join("",reversedNumber));
            }
            Console.WriteLine(numbersArray.Sum());
        }
    }
}
