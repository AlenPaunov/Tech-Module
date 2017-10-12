using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNameOfLastDigit
{
    class EnglishNameOfLastDigit
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToArray();
            int lastDigit = int.Parse(input.Last().ToString());
            Console.WriteLine(DigitToWord(lastDigit));
        }
        static string DigitToWord(int digit)
        {
            int[] digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] digitWords = new string[] {"zero", "one","two", "three", "four",
            "five", "six","seven", "eight","nine"};
            int position = Array.IndexOf(digits, digit);
            string word = digitWords[position];
            return word;
        }
    }
}
