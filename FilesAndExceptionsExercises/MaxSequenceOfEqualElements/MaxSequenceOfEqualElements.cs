using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            string outputPath = @"..\..\..\Output\output_4.txt";
            File.Delete(outputPath);

            int[] array = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();
            int start = 0, len = 1, bestStart = 0, bestLen = 1;

            for (int position = 1; position < array.Length; position++)
            {
                if (array[position] == array[position - 1])
                {
                    len++;
                    if (len > bestLen)
                    {
                        bestStart = start;
                        bestLen = len;
                    }
                }
                else
                {
                    len = 1;
                    start = position;
                }
            }
            for (int i = 0; i < bestLen; i++)
            {
               File.AppendAllText(outputPath,(array[bestStart + i]).ToString() + " ");
            }
            File.AppendAllText(outputPath,Environment.NewLine);
        }
    }
}
