using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddFilter
{
    class OddFilter
    {
        static void Main(string[] args)
        {
            List<int> integers = ReadIntegers();
            integers = RemoveOddNumbers(integers);
            integers = ConvertIntegers(integers);
            PrintIntegers(integers);
            
        }

        public static List<int> ReadIntegers()
        {

            List<int> integers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            return integers;
        }

        public static List<int> RemoveOddNumbers(List<int> integers)
        {
            List<int> evenIntegers = new List<int>();
            foreach (var integer in integers)
            {
                if (integer % 2 == 0)
                {
                    evenIntegers.Add(integer);
                }
            }
            return evenIntegers;
        }

        public static List<int> ConvertIntegers(List<int> integers)
        {
            List<int> convertedIntegers = new List<int>();
            for (int a = 0; a < integers.Count; a++)
            {
                List<int> remainingIntegers = integers.Where((v, i) => i != a).ToList();
                int integerToCheck = integers[a];
                if (integerToCheck > remainingIntegers.Average())
                {
                    integerToCheck += 1;
                }
                else
                {
                    integerToCheck -= 1;
                }
                convertedIntegers.Add(integerToCheck);
            }
            return convertedIntegers;
        }

        public static void PrintIntegers(List<int> integers)
        {
            Console.WriteLine(string.Join(" ",integers));
        }
    }
}
