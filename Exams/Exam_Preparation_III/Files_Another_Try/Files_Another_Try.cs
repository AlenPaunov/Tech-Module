using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Files
{
    class Files
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<folder>.*\\)(?<name>[^\\]+)\.(?<extension>[a-z]+);(?<size>\d+)";
            Regex regex = new Regex(pattern);

            int filesCount = int.Parse(Console.ReadLine());
            string[] input = new string[filesCount];
            for (int i = 0; i < filesCount; i++)
            {
                input[i] = Console.ReadLine();
            }

            string[] searchTokens = Console.ReadLine().Split(' ');
            string searchExtension = searchTokens[0].Trim();
            string searchRoot = searchTokens[2].Trim();

            //folder+file, FILE
            Dictionary<string, File> files = new Dictionary<string, File>();

            for (int i = 0; i < filesCount; i++)
            {
                Match match = regex.Match(input[i]);
                if (Regex.Match(match.Value, @"[\\]{2,}").Success)
                {
                    continue;
                }

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string[] folderParams = match.Groups["folder"].Value.Split(new string[] { "\\" }, StringSplitOptions.None);
                    string root = folderParams[0].Trim();
                    string folder = "";
                    string extension = match.Groups["extension"].Value;
                    string size = match.Groups["size"].Value;

                    folder = string.Join("\\",folderParams.Skip(1));

                    File file = new File(name, extension, size, folder);

                    if (searchRoot == root && searchExtension == file.Extension)
                    {
                        if (!files.ContainsKey(folder + file.Name))
                        {
                            files.Add(folder + file.Name, file);
                        }
                        else
                        {
                            files[folder + file.Name].Size = file.Size;
                        }
                    }
                }
            }


            if (files.Count > 0)
            {
                foreach (var file in files.Values.OrderByDescending(x => x.Size).ThenBy(x => x.Name))
                {
                    Console.WriteLine($"{file.Name}.{file.Extension} - {file.Size} KB");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }

    class File
    {
        public string Name;
        public string Extension;
        public long Size;
        public string Folder;

        public File(string name, string extension, string size, string folder)
        {
            Name = name;
            Extension = extension;
            Size = long.Parse(size);
            Folder = folder;
        }
    }
}
