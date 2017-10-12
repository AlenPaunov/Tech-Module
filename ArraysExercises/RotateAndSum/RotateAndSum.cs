using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateAndSum
{
    class RotateAndSum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
        
            array = ArrayRotator.RotateAndSum(array, rotations);
            array.PrintArray();
        }
    }
    public static class ArrayRotator
    {
        public static int[] RotateAndSum(int[] array, int count)
        {
            int[] sumArray = new int[array.Length];

            for (int a = 0; a < count; a++)
            {
                array.RotateArray(1);
                for (int i = 0; i < array.Length; i++)
                {
                    sumArray[i] += array[i];
                }
            }
            return sumArray;
        }

        public static void RotateArray<T>(this T[] array, int count)
        {
            if (array == null || array.Length < 2) return;
            count %= array.Length;
            if (count == 0) return;
            int left = count < 0 ? -count : array.Length + count;
            int right = count > 0 ? count : array.Length - count;
            if (left <= right)
            {
                for (int i = 0; i < left; i++)
                {
                    var temp = array[0];
                    Array.Copy(array, 1, array, 0, array.Length - 1);
                    array[array.Length - 1] = temp;
                }
            }
            else
            {
                for (int i = 0; i < right; i++)
                {
                    var temp = array[array.Length - 1];
                    Array.Copy(array, 0, array, 1, array.Length - 1);
                    array[0] = temp;
                }
            }
        }

        public static void PrintArray<T>(this T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }

        public static void SumArrays(this int[] array, int[] arrayToAdd)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] += arrayToAdd[i];
            }
        }
    }
}
