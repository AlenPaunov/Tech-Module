using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main(string[] args)
        {
            File.Delete(@"..\..\output.txt");

            List<char> lettersLowerCase = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToList();
            char[] input = File.ReadAllText(@"..\..\input.txt").ToCharArray();

            foreach (var letter in input)
            {
                File.AppendAllText(@"..\..\output.txt", $"{ letter} -> {lettersLowerCase.FindIndex(l => l == letter)}" + Environment.NewLine);
            }
        }
    }
}
