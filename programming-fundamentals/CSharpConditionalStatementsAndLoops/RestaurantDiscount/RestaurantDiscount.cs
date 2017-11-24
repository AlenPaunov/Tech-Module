using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDiscount
{
    class RestaurantDiscount
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            double discount = 0.0;
            string hallName = "";
            double price = 0.0;

            if (groupSize>120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
            else
            {
                if (groupSize > 100)
                {
                    hallName = "Great Hall";
                    price = 7500;
                }
                else if (groupSize > 50)
                {
                    hallName = "Terrace";
                    price = 5000;
                }
                else
                {
                    hallName = "Small Hall";
                    price = 2500;
                }
                switch (package)
                {
                    case "Normal":
                        price += 500;
                        discount = 0.95;
                        break;
                    case "Gold":
                        price += 750;
                        discount = 0.90;
                        break;
                    case "Platinum":
                        price += 1000;
                        discount = 0.85;
                        break;
                }
                price *= discount;
                price /= groupSize;
                Console.WriteLine($"We can offer you the {hallName}");
                Console.WriteLine($"The price per person is {price:f2}$");
            }
        }
    }
}
