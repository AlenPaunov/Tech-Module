using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToList();

            string[] command = Console.ReadLine()
                .Split(' ');

            while (command[0] != "print")
            {
                switch (command[0])
                {
                    case "add":
                        numbersList.Insert
                            (int.Parse(command[1]),
                            int.Parse(command[2]));
                        break;

                    case "addMany":
                        for (int i = 2; i < command.Length; i++)
                        {
                            numbersList.Insert(int.Parse(command[1]) + i - 2, int.Parse(command[i]));
                        }
                        break;

                    case "contains":
                        int element = int.Parse(command[1]);
                        if (numbersList.Contains(element))
                        {
                            Console.WriteLine(numbersList.IndexOf(element));
                        }
                        else
                        {
                            Console.WriteLine(-1);
                        }
                        break;

                    case "remove":
                        int index = int.Parse(command[1]);
                        numbersList.RemoveAt(index);
                        break;

                    case "shift":
                        List<int> list = new List<int>();
                        int amount = int.Parse(command[1]);
                        amount = amount % numbersList.Count;
                        for (int i = 0; i < amount; i++)
                        {   
                            list.Add(numbersList[0]);
                            numbersList.Remove(numbersList[0]);
                        }
                        numbersList.AddRange(list);
                        break;

                    case "sumPairs":
                        numbersList = numbersList.SumPairs();
                        break;

                }
                command = Console.ReadLine().Split(' ');
            }
            numbersList.PrintList();
        }
    }
    public static class ArrayManipulations
    {
        public static void RotateList(List<int> numbersList, int number)
        {
            List<int> remove = numbersList.Take(number).ToList();
            numbersList.RemoveRange(0, number);
            numbersList.AddRange(remove);
        }

        public static List<int> SumPairs(this List<int> list)
        {
            var result = new List<int>();

            if (list.Count % 2 == 0)
            {
                for (int i = 0; i < list.Count - 1; i += 2)
                {
                    result.Add(list[i] + list[i + 1]);
                }
            }
            else
            {
                for (int i = 0; i < list.Count - 1; i += 2)
                {
                    result.Add(list[i] + list[i + 1]);
                }
                result.Add(list[list.Count - 1]);
            }

            return result;
        }

        public static void ShiftArray<T>(this T[] array, int count)
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

        public static void PrintList(this List<int> list)
        {
            Console.WriteLine($"[{string.Join(", ", list)}]");
        }
    }
}
