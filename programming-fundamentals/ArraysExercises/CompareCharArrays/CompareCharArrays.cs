using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            char[] arrayA = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] arrayB = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] shorterArray = arrayA.Length <= arrayB.Length ?
                arrayA : arrayB;
            char[] longerArray = arrayA.Length <= arrayB.Length ?
                arrayB : arrayA;

            int indexEnd = shorterArray.Length <= longerArray.Length ?
                shorterArray.Length : longerArray.Length;

            for (int i = 0; i < indexEnd; i++)
            {
                if (shorterArray[i] != longerArray[i])
                {
                    if (shorterArray[i] > longerArray[i])
                    {
                        longerArray.PrintArray();
                        shorterArray.PrintArray();
                        return;
                    }
                }
            }
            shorterArray.PrintArray();
            longerArray.PrintArray();
        }
    }
    public static class ArrayOperator
    {
        public static void PrintArray<T>(this T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();
        }
    }
}
