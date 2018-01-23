using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_For_A_Number
{
    class Search_For_A_Number
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int[] parameters = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            list.Take(parameters[0]);
            list.RemoveRange(0, parameters[1]);
            Console.WriteLine("{0}!",list.Contains(parameters[2])?"YES":"NO");
        }
    }
}
