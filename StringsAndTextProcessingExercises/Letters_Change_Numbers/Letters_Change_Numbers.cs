using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters_Change_Numbers
{
    class Letters_Change_Numbers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<double> numbers = new List<double>();

            foreach (var item in input)
            {
                double number = NakovOperator(item.ToCharArray());
                numbers.Add(number);
            }

            Console.WriteLine(numbers.Sum().ToString("f2"));

        }

        private static double NakovOperator(char[] input)
        {
            List<char> bigLetters = new List<char>();
            bigLetters = Enumerable.Range('A', 'Z' - 'A' + 1).
                     Select(c => (char)c).ToList();

            List<char> smallLetters = new List<char>();
            smallLetters = Enumerable.Range('a', 'z' - 'a' + 1).
                      Select(c => (char)c).ToList();

            double number = double.Parse(string.Join("", input.Skip(1).Take(input.Length - 2)));

            char firstLetter = input[0];
            char secondLetter = input[input.Length - 1];

            if (char.IsUpper(firstLetter))
            {
                number /= bigLetters.FindIndex(x => x == firstLetter) + 1;
            }
            else
            {
                number *= smallLetters.FindIndex(x => x == firstLetter) + 1;
            }

            if (char.IsUpper(secondLetter))
            {
                number -= bigLetters.FindIndex(x => x == secondLetter) + 1;
            }
            else
            {
                number += smallLetters.FindIndex(x => x == secondLetter) + 1;
            }

            return number;
        }
    }
}
