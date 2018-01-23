using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseADrink2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double totalPrice = 0.0;
            string drink = "";

            switch (profession.ToLower())
            {
                case "businessman":
                case "businesswoman":
                    drink = "Coffee";
                    totalPrice = quantity * 1.00;
                    break;
                case "softuni student":
                    drink = "Beer";
                    totalPrice = quantity * 1.70;
                    break;
                case "athlete":
                    drink = "Water";
                    totalPrice = quantity * 0.70;
                    break;
                default:
                    drink = "Tea";
                    totalPrice = quantity * 1.20;
                    break;
            }
            Console.WriteLine($"The {profession} has to pay {totalPrice:f2}.");
        }
    }
}
