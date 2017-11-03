using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweet_Dessert
{
    class Sweet_Dessert
    {
        static void Main(string[] args)
        {
            const int _portions = 6;
            const int _bananas = 2;
            const int _eggs = 4;
            const decimal _berries = 0.2M;

            decimal initialMoney = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            decimal priceBananas = decimal.Parse(Console.ReadLine());
            decimal priceEggs =    decimal.Parse(Console.ReadLine());
            decimal priceBerries = decimal.Parse(Console.ReadLine());

            int desertsNeeded = 1;
            if (guests%_portions==0)
            {
                desertsNeeded = guests / _portions;
            }
            else
            {
                desertsNeeded += guests / _portions;
            }

            decimal productCost = desertsNeeded *(_bananas * priceBananas + _eggs * priceEggs +  _berries * priceBerries);

            if (productCost<=initialMoney)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {productCost:f2}lv.");
            }
            else
            {
                decimal neededMoney = productCost - initialMoney;
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {neededMoney:f2}lv more.");
            }
        }
    }
}
