using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDatabase
{
    class SupermarketDatabase
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> database = new Dictionary<string, Product>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stocked")
                {
                    break;
                }

                Product product = Product.ReadProduct(input);
                AddProduct(database, product);
            }

            PrintDatabase(database);
        }

        private static void PrintDatabase(Dictionary<string, Product> database)
        {
            decimal grandTotal = 0;
            foreach (var product in database)
            {
                decimal productTotalPrice = (product.Value.Price * product.Value.Quantity);
                Console.WriteLine($"{product.Key}: ${product.Value.Price.ToString("f2")} * {product.Value.Quantity} = ${productTotalPrice.ToString("f2")}");
                grandTotal += productTotalPrice;
            }
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Grand Total: ${grandTotal:f2}");
        }

        private static void AddProduct(Dictionary<string, Product> database, Product product)
        {
            if (database.Any(x => x.Key == product.Name))
            {
                var existingProduct = database.First(x => x.Key == product.Name);
                if (existingProduct.Value.Price != product.Price)
                {
                    existingProduct.Value.Price = product.Price;
                }
                existingProduct.Value.Quantity += product.Quantity;
            }
            else
            {
                database.Add(product.Name, product);
            }
        }
    }

    class Product
    {
        public string Name;
        public decimal Price;
        public int Quantity;

        public Product()
        {

        }

        public static Product ReadProduct(string input)
        {
            string[] productParams = input.Split(' ').ToArray();
            Product product = new Product()
            {
                Name = productParams[0],
                Price = decimal.Parse(productParams[1]),
                Quantity = int.Parse(productParams[2])
            };
            return product;
        }
    }
}
