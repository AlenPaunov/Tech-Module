using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            File.Delete(@"..\..\..\Output\output_6.txt");
            string[] inputLines = File.ReadAllLines("input.txt");

            for (int i = 0; i < inputLines.Length; i += 2)
            {
                if (inputLines[i] == "stop" || inputLines[i + 1] == "stop")
                {
                    break;
                }

                string name = inputLines[i];
                string email = inputLines[i + 1];

                if (email.EndsWith(".uk") || email.EndsWith(".us"))
                {
                    continue;
                }
                var output = $"{name } -> {email}" + Environment.NewLine;
                File.AppendAllText(@"..\..\..\Output\output_6.txt", output);

            }
        }
    }
}
