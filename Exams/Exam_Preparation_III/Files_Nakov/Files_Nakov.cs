using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_Nakov
{
    class Files_Nakov
    {
        static void Main(string[] args)
        {
            int filesCount = int.Parse(Console.ReadLine());

            List<string> allFiles = new List<string>();
            for (int i = 0; i < filesCount; i++)
            {
                allFiles.Add(Console.ReadLine());
            }

            string[] searchTokens = Console.ReadLine().Split(' ');
            string searchExtension = "." + searchTokens[0].Trim();
            string searchRoot = searchTokens[2] + "\\";

            Dictionary<string, int> fileSize = new Dictionary<string, int>();
            foreach (var f in allFiles)
            {
                var fullFile = f.Split(';');
                var size = int.Parse(fullFile[1]);
                var path = fullFile[0];
                if (f.StartsWith(searchRoot) && path.EndsWith(searchExtension))
                {
                    var tokens = path.Split('\\');
                    var fileName = tokens[tokens.Length - 1];
                    fileSize[fileName] = size;
                }

            }
            var sorted = fileSize.ToArray().OrderByDescending(f => f.Value).ThenBy(f => f.Key);

            if (sorted.Count() > 0)
            {
                foreach (var f in sorted)
                {
                    Console.WriteLine($"{f.Key} - {f.Value} KB");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
