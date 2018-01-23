using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladybugs
{
    class Ladybugs
    {
        static void Main(string[] args)
        {
            int field = int.Parse(Console.ReadLine());
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] ladybugs = new int[field];

            foreach (int index in indexes.Where(x => x >= 0 && x < field))
            {
                ladybugs[index] = 1;
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                BugCommand command = new BugCommand(input);

                if (command.Index >= 0 && command.Index < field && ladybugs[command.Index] == 1)
                {
                    ladybugs[command.Index] = 0;

                    try
                    {
                        switch (command.Direction)
                        {
                            case "left":
                                while (ladybugs[command.Index - command.FlyLenght] == 1)
                                {
                                    command.Index -= command.FlyLenght;
                                }
                                ladybugs[command.Index - command.FlyLenght] = 1;
                                break;

                            case "right":
                                while (ladybugs[command.Index + command.FlyLenght] == 1)
                                {
                                    command.Index += command.FlyLenght;
                                }
                                ladybugs[command.Index + command.FlyLenght] = 1;
                                break;
                        }
                    }
                    catch (Exception) { }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", ladybugs));
        }
    }
    class BugCommand
    {
        public int Index;
        public string Direction;
        public int FlyLenght;

        public BugCommand(string input)
        {
            string[] tokens = input.Split(' ');
            Index = int.Parse(tokens[0]);
            Direction = tokens[1];
            FlyLenght = int.Parse(tokens[2]);
        }
    }
}
