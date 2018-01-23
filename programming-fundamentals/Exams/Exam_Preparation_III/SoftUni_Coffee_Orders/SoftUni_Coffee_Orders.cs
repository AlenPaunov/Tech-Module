using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Coffee_Orders
{
    class SoftUni_Coffee_Orders
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());
            decimal totalPrice = 0.0M;
            for (int i = 0; i < ordersCount; i++)
            {
                Order order = Order.Parse();
                Console.WriteLine($"The price for the coffee is: ${order.TotalPrice:f2}");
                totalPrice += order.TotalPrice;
            }
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
    class Order
    {
        public decimal PricePerCapsule;
        public decimal TotalPrice;
        public DateTime Date;
        public decimal Count;
        public int Days;

        public Order()
        {

        }

        public static Order Parse()
        {
            decimal price = decimal.Parse(Console.ReadLine());
            DateTime date = DateTime.ParseExact(Console.ReadLine(), @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            decimal count = decimal.Parse(Console.ReadLine());
            int days = DateTime.DaysInMonth(date.Year, date.Month);
            Order order = new Order()
            {
                PricePerCapsule = price,
                Date = date,
                Count = count,
                Days = days,
                TotalPrice = (days * count) * price
            };
            return order;
        }
    }
}
