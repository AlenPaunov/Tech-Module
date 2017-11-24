    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Magic_Exchangeable_Words
    {
        class Magic_Exchangeable_Words
        {
            static void Main(string[] args)
            {
                string[] input = Console.ReadLine().Split(' ');

                char[] wordOne = input[0].ToCharArray().Distinct().ToArray();
                char[] wordTwo = input[1].ToCharArray().Distinct().ToArray();

                if (wordOne.Length == wordTwo.Length)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
