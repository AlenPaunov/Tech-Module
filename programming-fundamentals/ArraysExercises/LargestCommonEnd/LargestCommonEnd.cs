using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestCommonEnd
{
    class LargestCommonEnd
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(' ').ToArray();
            string[] array2 = Console.ReadLine().Split(' ').ToArray();
            int counterLeft = 0;
            int counterRight = 0;


            int endIndex = array1.Length <= array2.Length ? array1
                .Length : array2.Length;
            for (int i = 0; i < endIndex; i++)
            {
                if (array1[i] == array2[i])
                {
                    counterLeft++;
                }
                else
                {
                    break;
                }
            }
            Array.Reverse(array1);
            Array.Reverse(array2);
            for (int i = 0; i < endIndex; i++)
            {
                if (array1[i] == array2[i])
                {
                    counterRight++;
                }
                else
                {
                    break;
                }
            }
            if (counterLeft == 0 && counterRight == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine("{0}", counterLeft > counterRight
                    ? counterLeft : counterRight);
            }
        }
    }
}
