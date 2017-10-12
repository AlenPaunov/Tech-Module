using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BePositive_Debugging
{
    class BePositive
    {
        public static void Main()
        {
            int sequencesCount = int.Parse(Console.ReadLine());

            for (int sequence = 1; sequence <= sequencesCount; sequence++)
            {
                string[] input = Console.ReadLine().Trim().Split(' ');
                var numbers = new List<int>();

                for (int j = 0; j < input.Length; j++)
                {
                    if (!input[j].Equals(string.Empty))
                    {
                        int num = int.Parse(input[j]);
                        numbers.Add(num);
                    }
                }

                bool found = false;

                for (int j = 0; j < numbers.Count; j++)
                {
                    int currentNum = numbers[j];

                    if (currentNum >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(currentNum);

                        found = true;
                    }
                    else
                    {
                        int nextnumber = j + 1 == numbers.Count ? 0 : numbers[j + 1];
                        currentNum += nextnumber;

                        if (currentNum >= 0)
                        {
                            if (found)
                            {
                                Console.Write(" ");
                            }

                            Console.Write(currentNum);

                            found = true;
                        }
                        j++;
                    }
                }
                
                if (!found)
                {
                    Console.Write("(empty)");
                }
                Console.WriteLine();
            }
        }
    }
}
