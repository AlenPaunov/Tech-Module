using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Interpreter
{
    class Command_Interpreter
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int start, count;

                switch (tokens[0])
                {

                    case "reverse":
                        start = int.Parse(tokens[2]);
                        count = int.Parse(tokens[4]);

                        if (count < 0 || start >= array.Length || start < 0 || start + count > array.Length)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        array = ArrayManipulator.ReverseArray(array, start, count);
                        break;

                    case "sort":
                        start = int.Parse(tokens[2]);
                        count = int.Parse(tokens[4]);

                        if (count < 0 || start >= array.Length || start < 0 || start + count > array.Length)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        array = ArrayManipulator.SortArray(array, start, count);
                        break;

                    case "rollLeft":
                        count = int.Parse(tokens[1]);

                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        array.RollLeft(count);
                        break;

                    case "rollRight":
                        count = int.Parse(tokens[1]);

                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        array.RollRight(count);
                        break;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine("[{0}]", string.Join(", ", array));
        }
    }
    public static class ArrayManipulator
    {
        public static void RollLeft(this string[] array, int count)
        {
            if (array.Length < 2) return;
            count %= array.Length;
            if (count == 0) return;

            string[] buffer = new string[count];
            Array.Copy(array, buffer, count);
            Array.Copy(array, count, array, 0, array.Length - count);
            Array.Copy(buffer, 0, array, array.Length - count, count);
        }

        public static void RollRight(this string[] array, int count)
        {
            count = -count;
            if (array == null || array.Length < 2) return;
            count %= array.Length;
            if (count == 0) return;

            int right = array.Length - count;

            for (int i = 0; i < right; i++)
            {
                var temp = array[array.Length - 1];
                Array.Copy(array, 0, array, 1, array.Length - 1);
                array[0] = temp;
            }
        }

        public static string[] ReverseArray(string[] array, int start, int count)
        {
            var array1 = array.Take(start).ToArray();
            var arrayReversed = array.Skip(start).Take(count).ToArray();
            Array.Reverse(arrayReversed);
            var array2 = array.Skip(start + count).ToArray();
            return array = array1.Concat(arrayReversed).ToArray().Concat(array2).ToArray();
        }

        public static string[] SortArray(string[] array, int start, int count)
        {
            var array1 = array.Take(start).ToArray();
            var arrayReversed = array.Skip(start).Take(count).ToArray();
            Array.Sort(arrayReversed);
            var array2 = array.Skip(start + count).ToArray();
            return array = array1.Concat(arrayReversed).ToArray().Concat(array2).ToArray();
        }

    }
}
