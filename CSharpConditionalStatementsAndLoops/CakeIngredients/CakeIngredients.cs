using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeIngredients
{
    class CakeIngredients
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); ;
            int ingredientsCount = 0;

            while (input != "Bake!")
            {
                Console.WriteLine($"Adding ingredient {input}.");
                ingredientsCount++;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Preparing cake with {ingredientsCount} ingredients.");
        }
    }
}
