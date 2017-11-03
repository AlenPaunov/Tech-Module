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

            Dictionary<string, Root> roots = new Dictionary<string, Root>();

            for (int i = 0; i < filesCount; i++)
            {
                Match match = regex.Match(Console.ReadLine());

                if (match.Success)
                {
                    string name = match.Groups["name"].Value.Trim();
                    string [] folderParams = match.Groups["folder"].Value.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    string rootText = folderParams[0].Trim();
                    string folderText = "";
                    int folderParamsLen = folderParams.Length;
                    for (int z = 1; z < folderParamsLen-1; z++)
                    {
                        folderText = string.Join("\\", folderText, folderParams[z]);
                    }
                    folderText = string.Join("",folderText.Skip(1));
                    string extension = match.Groups["extension"].Value.Trim();
                    string size = match.Groups["size"].Value.Trim();

                    Root root = new Root()
                    {
                        Name = rootText,
                        Folders = new List<Folder>()
                    };

                    Folder folder = new Folder()
                    {
                        Name = folderText,
                        Files = new List<File>()
                    };

                    File file = new File(name, extension, size);

                    if (!roots.ContainsKey(root.Name))
                    {
                        roots.Add(root.Name, root);
                    }
                    if (!roots[root.Name].Folders.Any(f => f.Name == folder.Name))
                    {
                        roots[root.Name].Folders.Add(folder);
                    }
                    if (!roots[root.Name].Folders.Find(f => f.Name == folder.Name).Files.Any(f => f.Name == file.Name && f.Extension == file.Extension))
                    {
                        roots[root.Name].Folders.Find(f => f.Name == folder.Name).Files.Add(file);
                    }
                    else
                    {
                        roots[root.Name].Folders.Find(f => f.Name == folder.Name).Files.Find(f => f.Name == file.Name && f.Extension == file.Extension).Size = file.Size;
                    }
                }
            }
            
            string[] searchTokens = Console.ReadLine().Split(' ');
            string searchExtension = searchTokens[0].Trim();
            string searchRoot = searchTokens[2].Trim();

            List<File> foundFiles = new List<File>();
            foreach (var root in roots.Where(r => r.Key == searchRoot))
            {
                foreach (var folder in root.Value.Folders)
                {
                    foreach (var file in folder.Files.Where(f => f.Extension == searchExtension))
                    {
                        foundFiles.Add(file);
                    }
                }
            }

            if (foundFiles.Count > 0)
            {
                foreach (var file in foundFiles.OrderByDescending(f => f.Size).ThenBy(f => f.Name))
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

        public File(string name, string extension, string size)
        {
            Name = name;
            Extension = extension;
            Size = long.Parse(size);
        }
    }

    class Root
    {
        public string Name;
        public List<Folder> Folders;

        public Root()
        {

        }

    }
    class Folder
    {
        public string Name;
        public List<File> Files;

        public Folder()
        {

        }
    }
}
