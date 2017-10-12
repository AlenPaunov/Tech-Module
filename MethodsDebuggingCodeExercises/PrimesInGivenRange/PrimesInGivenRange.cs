using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesInGivenRange
{
    class PrimesInGivenRange
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            PrintListPrimes(FindPrimesInRange(startNum, endNum));
        }

        public static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> list = new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public static void PrintListPrimes(List<int> list)
        {
            StringBuilder builder = new StringBuilder();

            foreach (int item in list)
            {
                builder.Append(item.ToString() + ", ");
            }
            builder.Remove(builder.Length - 2, 2);

            Console.WriteLine(builder.ToString());
        }

        private static bool IsPrime(long num)
        {
            if (num < 2) return false;
            if (num == 2) return true;

            var boundary = Math.Sqrt(num);
            for (long i = 2; i <= boundary; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }
}
