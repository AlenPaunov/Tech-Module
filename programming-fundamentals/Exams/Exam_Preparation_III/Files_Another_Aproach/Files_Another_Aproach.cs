using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_Another_Aproach
{
    class Files_Another_Aproach
    {
        static void Main(string[] args)
        {
            int filesCount = int.Parse(Console.ReadLine());
            Dictionary<string, Root> roots = new Dictionary<string, Root>();

            for (int i = 0; i < filesCount; i++)
            {
                string[] line = Console.ReadLine().Split('\\');
                string rootName = line[0].Trim();
                int folderLen = line.Length;
                string folder = "";
                for (int f = 1; f < folderLen - 1; f++)
                {
                    folder = string.Concat(folder, line[f].Trim());
                }

                string[] fileInfo = line.Last().Split(';');
                string fileSize = fileInfo.Last().Trim();
                string[] fileTokens = fileInfo[0].Split('.');
                int fileLenght = fileTokens.Length;
                string fileName = null;

                if (fileLenght > 2)
                {
                    for (int a = 0; a < fileLenght - 1; a++)
                    {
                        fileName = string.Join(".",fileName, fileTokens[a]);
                    }
                    fileName = string.Join("",fileName.Skip(1));
                }
                else
                {
                    fileName = fileTokens[0];
                }

                string fileExtension = fileTokens.Last();

                Root root = new Root()
                {
                    Name = rootName,
                    Files = new Dictionary<string, Dictionary<string, File>>()

                };
                File file = new File(fileName, fileExtension, fileSize);

                if (!roots.ContainsKey(root.Name))
                {
                    roots.Add(root.Name, root);
                }
                if (!roots[root.Name].Files.Any(f => f.Key == folder))
                {
                    roots[root.Name].Files.Add(folder,new Dictionary<string, File>());
                }
                if (!roots[root.Name].Files[folder].Any(f=>f.Key==file.Name))
                {
                    roots[rootName].Files[folder].Add(file.Name, file);
                }
                else
                {
                    roots[root.Name].Files[folder][file.Name].Size = file.Size;
                }
            }

            string[] searchTokens = Console.ReadLine().Split(' ');
            string searchExtension = searchTokens[0].Trim();
            string searchRoot = searchTokens[2].Trim();
            List<File> foundFiles = new List<File>();

            foreach (var root in roots.Where(r => r.Key == searchRoot))
            {
                foreach (var folder in roots[searchRoot].Files.Where(x=>x.Value.Any(a=>a.Value.Extension==searchExtension)))
                {
                    foreach (var file in folder.Value.Where(f=>f.Value.Extension==searchExtension))
                    {
                        foundFiles.Add(file.Value);
                    }
                }
            }
            if (foundFiles.Count > 0)
            {
                foreach (var file in foundFiles.OrderByDescending(x => x.Size).ThenBy(a => a.Name))
                {
                    Console.WriteLine($"{file.Name.Trim()}.{file.Extension.Trim()} - {file.Size} KB");
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
        // folder, <filename, file>;
        public Dictionary<string, Dictionary<string, File>> Files;
    }
}
