using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSums
{
    class EqualSums
    {
        static void Main(string[] args)
        {
            string outputPath = @"..\..\..\Output\output_3.txt";
            File.Delete(outputPath);

            int[] array = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();

            if (array.Length == 1)
            {
               File.WriteAllText(outputPath, "0");
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array.Sum() - array[i] - array.Skip(i + 1).Sum() == array.Skip(i + 1).Sum())
                {
                    File.WriteAllText(outputPath, i.ToString());
                    return;
                }
            }
            File.WriteAllText(outputPath, "no");
        }
    }
}
