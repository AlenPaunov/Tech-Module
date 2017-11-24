using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace TakeSkipRope
{
    class TakeSkipRope
    {
        static void Main(string[] args)
            {
            string [] encrypded = Console.ReadLine().Select(x => new string(x, 1)).ToArray();
            List<int> numberList = new List<int>();
            List<string> nonNumberList = new List<string>();

            foreach (var item in encrypded)
            {
                try
                {
                    numberList.Add(int.Parse(item));
                }
                catch (Exception)
                {
                    nonNumberList.Add(item);
                }
            }           

            List<int> skipList = new List<int>();
            List<int> takeList = new List<int>();

            for (int i = 0; i < numberList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numberList[i]);
                }
                else
                {
                    skipList.Add(numberList[i]);
                }
            }

            StringBuilder builder = new StringBuilder();
            int skip = 0;
            for (int i = 0; i < takeList.Count; i++)
            {
                string take = string.Join("",nonNumberList.Skip(skip).Take(takeList[i]));
                builder.Append(take);
                skip += skipList[i]+ takeList[i];
            }

            Console.WriteLine(builder);
        }
    }
}
