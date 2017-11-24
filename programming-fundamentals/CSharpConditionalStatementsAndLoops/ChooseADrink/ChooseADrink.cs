using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseADrink
{
    class ChooseADrink
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            string drink = "";
            switch (input)
            {
                case "businessman":
                case "businesswoman":
                    drink = "Coffee";
                    break;
                case "softuni student":
                    drink = "Beer";
                    break;
                case "athlete":
                    drink = "Water";
                    break;
                default:
                    drink = "Tea";
                    break;
            }
            Console.WriteLine(drink);
        }
    }
}
