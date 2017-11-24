using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Manipulator
{
    class Array_Manipulator
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end") break;
                string[] command = line.Split(' ');
                ArrayManipulator.Commander(array, command);
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }
    }

    public static class ArrayManipulator
    {
        public static void Commander(this int[] array, string[] command)
        {
            switch (command[0])
            {
                case "exchange":
                    array.Exchange(long.Parse(command[1]));
                    break;

                case "max":
                    array.Max(command[1]);
                    break;

                case "min":
                    array.Min(command[1]);
                    break;

                case "first":
                    array.First(long.Parse(command[1]), command[2]);
                    break;

                case "last":
                    array.Last(long.Parse(command[1]), command[2]);
                    break;

            }
        }

        public static void Exchange(this int[] array, long index)
        {
            if (index >= array.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            var firstArr = array.Take((int)index + 1).ToArray();
            var secondArr = array.Skip((int)index + 1).ToArray();

            Array.Copy(secondArr, array, secondArr.Length);
            Array.Copy(firstArr, 0, array, secondArr.Length, firstArr.Length);
        }

        public static void Max(this int[] array, string evenOdd)
        {
            int index = -1;

            bool found = false;
            switch (evenOdd)
            {
                case "even":
                    int tempMin = int.MinValue;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == 0)
                        {
                            if (tempMin <= array[i])
                            {
                                tempMin = array[i];
                                index = i;
                                found = true;
                            }
                        }
                    }
                    break;

                case "odd":
                    int tempMax = int.MinValue;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 != 0)
                        {
                            if (tempMax <= array[i])
                            {
                                tempMax = array[i];
                                index = i;
                                found = true;
                            }

                        }
                    }
                    break;
            }
            if (!found)
            {
                Console.WriteLine("No matches");
                return;
            }
            Console.WriteLine(index);
        }

        public static void Min(this int[] array, string evenOdd)
        {
            int index = -1;

            bool found = false;
            switch (evenOdd)
            {
                case "even":
                    int tempMin = int.MaxValue;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 == 0)
                        {
                            if (tempMin >= array[i])
                            {
                                tempMin = array[i];
                                index = i;
                                found = true;
                            }
                        }
                    }
                    break;

                case "odd":
                    int tempMax = int.MaxValue;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] % 2 != 0)
                        {
                            if (tempMax >= array[i])
                            {
                                tempMax = array[i];
                                index = i;
                                found = true;
                            }
                        }
                    }
                    break;
            }
            if (!found)
            {
                Console.WriteLine("No matches");
                return;
            }
            Console.WriteLine(index);
        }

        public static void First(this int[] array, long n, string evenOdd)
        {
            if (n < 0 || n > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            List<int> output = new List<int>();
            switch (evenOdd)
            {
                case "even":

                    for (int i = 0; i < array.Length; i++)
                    {
                        if (output.Count >= n)
                        {
                            break;
                        }
                        if (array[i] % 2 == 0)
                        {
                            output.Add(array[i]);
                        }

                    }
                    break;

                case "odd":
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (output.Count >= n)
                        {
                            break;
                        }
                        if (array[i] % 2 != 0)
                        {
                            output.Add(array[i]);
                        }
                    }
                    break;
            }

            Console.WriteLine($"[{string.Join(", ", output)}]");

        }

        public static void Last(this int[] array, long n, string evenOdd)
        {
            if (n < 0 || n > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            List<int> output = new List<int>();
            int[] tempArray = array.Reverse().ToArray();

            switch (evenOdd)
            {

                case "even":

                    for (int i = 0; i < array.Length; i++)
                    {
                        if (output.Count >= n)
                        {
                            break;
                        }
                        if (tempArray[i] % 2 == 0)
                        {
                            output.Add(tempArray[i]);
                        }

                    }
                    break;

                case "odd":
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (output.Count >= n)
                        {
                            break;
                        }
                        if (tempArray[i] % 2 != 0)
                        {
                            output.Add(tempArray[i]);
                        }
                    }
                    break;
            }
            output.Reverse();
            Console.WriteLine($"[{string.Join(", ", output)}]");

        }
    }
}
