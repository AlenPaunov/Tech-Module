using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main(string[] args)
        {
            char[] lowerChars = Enumerable.Range(97, 26).Select(c => (Char)c).ToArray();

            char[] array = Console.ReadLine().ToArray();

            foreach (char letter in array)
            {
                Console.WriteLine("{0} -> {1}", letter, Array.IndexOf(lowerChars, letter));
            }
        }
    }
}
