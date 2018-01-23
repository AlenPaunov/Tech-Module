using System;
using System.Linq;
using System.Numerics;

namespace Convert_From_BaseN_To_Base10
{
    class Convert_From_BaseN_To_Base10
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            int initialBase = int.Parse(input[0]);
            char[] numberToConvert = input[1].ToCharArray();
            Console.WriteLine(ConvertToBaseTen(initialBase,numberToConvert));
        }

        static string ConvertToBaseTen(int initialBase, char[] numberToConvert)
        {
            BigInteger result = 0;

            for (int i = numberToConvert.Length - 1, n = 0; i >= 0; i--, n++)
            {
                BigInteger number = new BigInteger(char.GetNumericValue(numberToConvert[n]));
                BigInteger addToResult = number * BigInteger.Pow(initialBase, i);
                result += addToResult;
            }
            return result.ToString();
        }
    }
}
