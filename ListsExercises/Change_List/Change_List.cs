using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Change_List
{
    class Change_List
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');

                switch (command[0])
                {
                    case "Delete":
                        list.DeleteElement(int.Parse(command[1]));
                        break;
                    case "Insert":
                        list.InsertElement(int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "Odd":
                        list.PrintElements(false);
                        return;
                    case "Even":
                        list.PrintElements(true);
                        return;
                }

            }
        }
    }
    public static class ListOperator
    {
        public static void InsertElement(this List<int> list, int valueToInsert, int position)
        {
            list.Insert(position, valueToInsert);
        }

        public static void DeleteElement(this List<int> list, int valueToDelete)
        {
            list.RemoveAll(x => x == valueToDelete);
        }

        public static void PrintElements(this List<int> list, bool even)
        {
            if (even)
            {
                foreach (int item in list)
                {
                    if (item % 2 == 0)
                    {
                        Console.Write(item.ToString() + " ");
                    }
                }
            }
            else
            {
                foreach (int item in list)
                {
                    if (item % 2 != 0)
                    {
                        Console.Write(item.ToString() + " ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
