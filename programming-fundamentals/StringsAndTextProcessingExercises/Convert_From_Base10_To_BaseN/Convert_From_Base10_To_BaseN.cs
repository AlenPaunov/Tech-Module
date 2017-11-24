using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Convert_From_Base10_To_BaseN
{
    class Convert_From_Base10_To_BaseN
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine().Split(' ').Select(x => BigInteger.Parse(x)).ToArray();

            string result = ConvertToBase(input[1], input[0]);

            Console.WriteLine(result);

        }

        static string ConvertToBase(BigInteger numberBaseTen, BigInteger baseToConvert)
        {
            Stack<BigInteger> converted = new Stack<BigInteger>();

            while (numberBaseTen != 0)
            {
                BigInteger num = numberBaseTen % baseToConvert;
                converted.Push(num);
                numberBaseTen /= baseToConvert;
            }

            StringBuilder builder = new StringBuilder();
            while (converted.Count != 0)
            {
                builder.Append(converted.Pop());
            }
            
            return (builder.ToString());
        }
    }
}
