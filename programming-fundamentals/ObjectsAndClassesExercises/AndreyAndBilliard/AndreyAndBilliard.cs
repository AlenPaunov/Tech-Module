using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreyAndBilliard
{
    class AndreyAndBilliard
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> shop = new Dictionary<string, decimal>();
            int productsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < productsCount; i++)
            {
                string[] input = Console.ReadLine().Split('-');
                if (!shop.ContainsKey(input[0]))
                {
                    shop.Add(input[0], decimal.Parse(input[1]));
                }
                else
                {
                    shop[input[0]] = decimal.Parse(input[1]);
                }

            }
            List<Customer> customers = new List<Customer>();
            while (true)
            {
                string info = Console.ReadLine();
                if (info == "end of clients")
                {
                    break;
                }
                string[] customerInfo = info.Split('-', ',');
                string customerName = customerInfo[0];
                string product = customerInfo[1];
                int quantity = int.Parse(customerInfo[2]);

                if (!shop.ContainsKey(product)) { continue; }

                Customer customer = new Customer
                {
                    ShopList = new Dictionary<string, int>(),
                    Name = customerName
                };
                customer.ShopList.Add(product, quantity);

                if (customers.Any(c => c.Name == customerName))
                {
                    Customer existingCustomer = customers.First(c => c.Name == customerName);
                    if (existingCustomer.ShopList.ContainsKey(product))
                    {
                        existingCustomer.ShopList[product] += quantity;
                    }
                    else
                    {
                        existingCustomer.ShopList[product] = quantity;
                    }
                }
                else
                {
                    customers.Add(customer);
                }
            }
           // calc bill
            foreach (Customer customer in customers)
            {
                Customer.GetBill(customer, shop);
            }

            var ordered = customers
                            .OrderBy(x => x.Name)
                            .ThenBy(x => x.Bill)
                            .ToList();

            foreach (var customer in ordered)
            {
                Console.WriteLine(customer.Name);
                foreach (KeyValuePair<string, int> item in customer.ShopList)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine("Bill: {0:f2}", customer.Bill);
            }
            Console.WriteLine("Total bill: {0:F2}", customers.Sum(c => c.Bill));
        }
    }
}

public class Customer
{
    public string Name;
    public Dictionary<string, int> ShopList;

    public decimal Bill;

    public static void GetBill(Customer customer, Dictionary<string, decimal> shop)
    {
        foreach (var item in customer.ShopList)
        {
            foreach (var product in shop)
            {
                if (item.Key == product.Key)
                {
                    customer.Bill += item.Value * product.Value;
                }
            }
        }
    }
}

