using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCounter
{
    class CaloriesCounter
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int totalCalories = 0;

            for (int i = 0; i < input; i++)
            {
                string ingredient = Console.ReadLine();
                switch (ingredient.ToLower())
                {
                    case "cheese":
                        totalCalories += 500;
                        break;
                    case "tomato sauce":
                        totalCalories += 150;
                        break;
                    case "salami":
                        totalCalories += 600;
                        break;
                    case "pepper":
                        totalCalories += 50;
                        break;
                }
            }
            Console.WriteLine($"Total calories: {totalCalories}");
        }
    }
}
