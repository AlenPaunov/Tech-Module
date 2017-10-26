using System;
using System.Collections.Generic;
using System.IO;

namespace AMinerTask
{
    class AMinerTask
    {
        static void Main(string[] args)
        {
            string outputPath = @"..\..\..\Output\output_5.txt";
            File.Delete(outputPath);
            string [] input = File.ReadAllLines("input.txt");

            var dictionary = new Dictionary<string, int>();
            int value;
            int i = 0;
            string resourse = input[i]
              .Trim();
            i++;

            while (resourse != "stop")
            {
                value = int.Parse(input[i]
                  .Trim());
                i++;

                if (dictionary.ContainsKey(resourse))
                {
                    dictionary[resourse] += value;
                }
                else
                {
                    dictionary.Add(resourse, value);
                }

                resourse = input[i];
                i++;
            }

            foreach (var item in dictionary)
            {
                File.AppendAllText(outputPath,$"{item.Key} -> {item.Value}" + Environment.NewLine );
            }
        }
    }
}
