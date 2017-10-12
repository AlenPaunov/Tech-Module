using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNumbers
{
    class GameOfNumbers
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicalNumber = int.Parse(Console.ReadLine());
            int combinationsCount = 0;
            string output = "";

            for (int a = firstNumber; a <= secondNumber; a++)
            {
                for (int b = firstNumber; b <= secondNumber; b++)
                {

                    combinationsCount++;
                    if (a + b == magicalNumber)
                    {
                        output = $"Number found! {b} + {a} = {a + b}";
                        break;
                    }
                }

                if (output != "")
                {
                    break;
                }
            }
            if (output == "")
            {
                output = $"{combinationsCount} combinations - neither equals {magicalNumber}";
            }
            Console.WriteLine(output);
        }
    }
}
