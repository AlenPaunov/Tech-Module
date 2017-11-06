using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Anonymous_Cache
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, Dictionary<string, long>> cache = new Dictionary<string, Dictionary<string, long>>();

            string line = Console.ReadLine();

            while (line != "thetinggoesskrra")
            {
                if (line.Contains("|"))
                {
                    var tokens = line.Split(new string[] { " | ", " -> " }, StringSplitOptions.None);

                    var dataSet = tokens[2];
                    var dataKey = tokens[0];
                    var dataSize = int.Parse(tokens[1]);

                    if (data.ContainsKey(dataSet))
                    {
                        if (!data[dataSet].ContainsKey(dataKey))
                        {
                            data[dataSet].Add(dataKey, dataSize);
                        }
                        else
                        {
                            data[dataSet][dataKey] += dataSize;
                        }

                    }
                    else
                    {
                        if (!cache.ContainsKey(dataSet))
                        {
                            cache.Add(dataSet, new Dictionary<string, long>());
                        }

                        if (!cache[dataSet].ContainsKey(dataKey))
                        {
                            cache[dataSet].Add(dataKey, dataSize);
                        }
                        else
                        {
                            cache[dataSet][dataKey] += dataSize;
                        }

                    }


                }
                else
                {
                    if (!data.ContainsKey(line))
                    {
                        data.Add(line, new Dictionary<string, long>());

                        if (cache.ContainsKey(line))
                        {
                            data[line] = cache[line];
                            cache.Remove(line);
                        }
                    }

                }

                line = Console.ReadLine();
            }
            if (data.Count > 0)
            {
                var item = data.OrderByDescending(x => x.Value.Sum(a => a.Value)).First();

                var totalSum = item.Value.Sum(x => x.Value);
                Console.WriteLine($"Data Set: {item.Key}, Total Size: {totalSum}");
                foreach (var datakey in item.Value)
                {
                    Console.WriteLine($"$.{datakey.Key}");
                }

            }
        }
    }
}
