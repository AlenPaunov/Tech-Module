using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbersArray = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToList();

            int[] parameters = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int bombNumber = parameters[0];
            int bombPower = parameters[1];

            for (int i = 0; i < numbersArray.Count; i++)
            {
                if (numbersArray[i] == bombNumber)
                {
                    for (int j = 1; j <= bombPower; j++)
                    {
                        if (i - j < 0)
                        {
                            break;
                        }
                        else
                        {
                            numbersArray[i - j] = 0;
                        }
                    }

                    for (int j = 1; j <= bombPower; j++)
                    {
                        if (i + j > numbersArray.Count - 1)
                        {
                            break;
                        }
                        else
                        {
                            numbersArray[i + j] = 0;
                        }
                    }

                    numbersArray[i] = 0;
                }

            }
            numbersArray.RemoveAll(x => x == 0);
            int sum = numbersArray.Sum();
            Console.WriteLine(sum);
        }
    }
}
