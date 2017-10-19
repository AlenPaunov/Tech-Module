using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMinerTask
{
    class AMinerTask
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();
            int value;
            string resourse = Console.ReadLine()
              .Trim();


            while (resourse != "stop")
            {
                value = int.Parse(Console.ReadLine()
                  .Trim());

                if (dictionary.ContainsKey(resourse))
                {
                    dictionary[resourse] += value;
                }
                else
                {
                    dictionary.Add(resourse, value);
                }

                resourse = Console.ReadLine();
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
