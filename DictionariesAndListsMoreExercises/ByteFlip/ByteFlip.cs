using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteFlip
{
    class ByteFlip
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').Where(x => x.Length == 2).ToList();
            List<char> output = new List<char>();

            for (int i = input.Count- 1; i >= 0; i--)
            {
                char[] charArray = input[i].ToCharArray();
                Array.Reverse(charArray);
                output.Add(System.Convert.ToChar(System.Convert.ToUInt32(new string(charArray), 16)));
            }

            Console.WriteLine(string.Join("",output));
        }
    }
}
