using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phoenix_Grid
{
    class Phoenix_Grid
    {
        static void Main(string[] args)
        {
            
            string pattern = @"^([^_\s]{3})((\.)?([^_\s]{3})?)?(\.+([^_\s]{3})?)*$";
            string line = Console.ReadLine();

            while (line!="ReadMe")
            {
                bool IsValid = Regex.IsMatch(line, pattern);

                if (IsValid && IsPalindrome(line))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
                line = Console.ReadLine();
            }

        }
       
        static bool IsPalindrome(string line)
        {
            bool isPalindrome = false;
            switch (line.Count() % 2 == 0)
            {
                case true:
                    string evenF = string.Join("", line.Take(line.Length / 2).ToArray());
                    string evenS = string.Join("", line.Skip(line.Length / 2).Reverse().ToArray());
                    int foundEven = string.Compare(evenF, evenS);
                    if (foundEven == 0)
                    {
                        isPalindrome = true;
                    }
                    break;

                case false:
                    string oddF = string.Join("", line.Take(line.Length / 2).ToArray());
                    string oddS = string.Join("", line.Skip(line.Length / 2 + 1).Reverse().ToArray());
                    int foundOdd = string.Compare(oddF, oddS);
                    if (foundOdd == 0)
                    {
                        isPalindrome = true;
                    }
                    break;
            }
            return isPalindrome;
        }
        //static bool IsValid(string line)
        //{
        //    string[] parts = line.Split('.');

        //    foreach (var item in parts)
        //    {
        //        if (!Regex.Match(item, @"^[^_\s.]{3}$").Success)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

    }
}
