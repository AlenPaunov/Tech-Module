using System;
using System.Collections.Generic;
using System.Linq;


namespace Matrix_Operator
{
    class Matrix_Operator
    {
        static void Main(string[] args)
        {
            List<List<long>> table = new List<List<long>>();
            int rows = int.Parse(Console.ReadLine());
            string command = null;

            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();
                table.Add(new List<long>());
                table[i].AddRange(line.Split(' ').Select(x => long.Parse(x)).ToList());
            }

            if (command == null)
            {
                command = Console.ReadLine();
            }

            while (command != "end")
            {
                table.Commander(command);
                command = Console.ReadLine();
            }

            foreach (var row in table)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
    public static class MatrixOperator
    {
        public static void Commander(this List<List<long>> table, string command)
        {
            string[] commandTokens = command.Split(' ').ToArray();

            switch (commandTokens[0])
            {
                case "remove":
                    table.Remove(commandTokens[1], commandTokens[2], int.Parse(commandTokens[3]));
                    break;

                case "swap":
                    table.Swap(int.Parse(commandTokens[1]), int.Parse(commandTokens[2]));
                    break;

                case "insert":
                    table.Insert(int.Parse(commandTokens[1]), long.Parse(commandTokens[2]));
                    break;
            }
        }

        public static void Remove(this List<List<long>> table, string type, string position, int index)
        {

            switch (position)
            {
                case "row":
                    if (table.Count > index && index >= 0)
                    {
                        switch (type)
                        {
                            case "even":
                                table[index].RemoveAll(x => x % 2 == 0);
                                break;

                            case "odd":
                                table[index].RemoveAll(x => x % 2 != 0 && x != 0);
                                break;

                            case "positive":
                                table[index].RemoveAll(x => x >= 0);
                                break;

                            case "negative":
                                table[index].RemoveAll(x => x < 0);
                                break;
                        }

                    }

                    break;

                case "col":
                    foreach (var row in table.Where(x => x.Count > index))
                    {

                        if (index >= 0)
                        {
                            switch (type)
                            {
                                case "even":
                                    if (row[index] % 2 == 0)
                                    {
                                        row.RemoveAt(index);
                                    }
                                    break;

                                case "odd":
                                    if (row[index] % 2 != 0)
                                    {
                                        row.RemoveAt(index);
                                    }
                                    break;

                                case "positive":
                                    if (row[index] >= 0)
                                    {
                                        row.RemoveAt(index);
                                    }
                                    break;

                                case "negative":
                                    if (row[index] < 0)
                                    {
                                        row.RemoveAt(index);
                                    }
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        public static void Swap(this List<List<long>> table, int firstRow, int secondRow)
        {
            if (table.Count > firstRow && table.Count > secondRow && firstRow >= 0 && secondRow >= 0)
            {
                var tempList = table[firstRow];
                table[firstRow] = table[secondRow];
                table[secondRow] = tempList;
            }
        }

        public static void Insert(this List<List<long>> table, int row, long number)
        {
            if (table.Count > row && row >= 0)
            {
                table[row].Insert(0, number);
            }
        }
    }
}