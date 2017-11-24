using System;
using System.Collections.Generic;
using System.Linq;

namespace Icarus
{
    class Icarus
    {
        static void Main(string[] args)
        {
            int[] thePlane = Console.ReadLine()
                  .Split().Select(int.Parse).ToArray();

            int index = int.Parse(Console.ReadLine());

            int damage = 1;

            string command = Console.ReadLine();
            while (command != "Supernova")
            {
                string[] myArr = command.Split();
                string direction = myArr[0];
                int steps = int.Parse(myArr[1]);

                switch (direction)
                {
                    case "left":

                        for (int i = 0; i < steps; i++)
                        {
                            index--;

                            if (index < 0)
                            {
                                index = thePlane.Length - 1;
                                damage++;
                            }
                            thePlane[index] -= damage;
                        }

                        break;

                    case "right":

                        for (int i = 0; i < steps; i++)
                        {
                            index++;

                            if (index > thePlane.Length - 1)
                            {
                                index = 0;
                                damage++;
                            }

                            thePlane[index] -= damage;
                        }
                        break;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", thePlane));
        }
    }
    public class Phoenix
    {
        public int Damage;
        public int Position;
    }
    public class Position
    {
        public int Health;
        public bool IsNew = true;
    }
    public static class IcarusRotator
    {
        public static void Commander(this Phoenix phoenix, ref Dictionary<int, Position> plane, string command)
        {
            string[] commandTokens = command.Split(' ');
            string direction = commandTokens[0];
            int steps = int.Parse(commandTokens[1]);

            if (steps == 0)
            {
                return;
            }

            switch (direction)
            {
                case "right":
                    phoenix.GoRight(ref plane, steps);
                    break;

                case "left":
                    phoenix.GoLeft(ref plane, steps);
                    break;
            }

        }

        public static void GoRight(this Phoenix phoenix, ref Dictionary<int, Position> plane, int steps)
        {

            int pos = phoenix.Position + 1;
            for (int i = 1; i <= steps; i++)
            {
                if (pos >= plane.Count)
                {
                    pos = 0;
                    phoenix.Damage++;

                }
                if (plane[pos].Health > 0)
                {
                    plane[pos].Health -= phoenix.Damage;

                }
                phoenix.Position = pos;
                pos++;
            }

        }

        public static void GoLeft(this Phoenix phoenix, ref Dictionary<int, Position> plane, int steps)
        {
            int pos = phoenix.Position - 1;

            for (int i = 1; i <= steps; i++)
            {
                if (pos < 0)
                {
                    pos = plane.Count - 1;
                    phoenix.Damage++;

                }
                if (plane[pos].Health > 0)
                {
                    plane[pos].Health -= phoenix.Damage;

                }

                phoenix.Position = pos;
                pos--;
            }
        }
    }
}
