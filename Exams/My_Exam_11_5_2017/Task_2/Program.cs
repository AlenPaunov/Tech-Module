using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> list = Console.ReadLine().Split(' ').ToList();


            string line = Console.ReadLine();
            while (line != "3:1")
            {
                string[] tokens = line.Split(' ');

                switch (tokens[0])
                {
                    case "merge":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);


                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        if (endIndex >= list.Count())
                        {
                            endIndex = list.Count() - 1;
                        }
                        if (startIndex < list.Count)
                        {
                            StringBuilder builder = new StringBuilder();

                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                builder.Append(list[i]);
                            }

                            list[startIndex] = builder.ToString();
                            for (int i = 1; i <= endIndex - startIndex; i++)
                            {
                                list.RemoveAt(startIndex + 1);
                            }
                        }

                        break;


                    case "divide":

                        int index = int.Parse(tokens[1]);
                        int parts = int.Parse(tokens[2]);

                        if (index >= 0 && index < list.Count)
                        {
                            var word = list[index];

                            List<string> spllited = new List<string>();

                            if (word.Length % parts == 0)
                            {

                                for (int i = 0; i < word.Length % parts; i++)
                                {
                                    var add = new string(word.Take(word.Length / parts).ToArray());
                                    word = new string(word.Skip(word.Length / parts).ToArray());

                                    spllited.Add(add);
                                }

                            }
                            List<string> result2 = new List<string>();
                            for (int i = 0; i < index; i++)
                            {
                                result2.Add(list[i]);
                            }
                            for (int i = 0; i < spllited.Count; i++)
                            {
                                result2.Add(spllited[i]);
                            }
                          

                            for (int i = index+1; i < list.Count; i++)
                            {
                                result2.Add(list[i]);
                            }

                            list = result2;


                        }
                        else
                        {
                            var word = list[index];

                            List<string> spllited = new List<string>();

                            if (word.Length % parts == 0)
                            {
                                var add = "";
                                for (int i = 0; i < word.Length % parts-1; i++)
                                {
                                    add = new string(word.Take(word.Length / parts).ToArray());
                                    word = new string(word.Skip(word.Length / parts).ToArray());

                                    spllited.Add(add);
                                }
                                spllited.Add(add);
                            }
                            List<string> result2 = new List<string>();
                            for (int i = 0; i < index; i++)
                            {
                                result2.Add(list[i]);
                            }
                            for (int i = 0; i < spllited.Count; i++)
                            {
                                result2.Add(spllited[i]);
                            }


                            for (int i = index + 1; i < list.Count; i++)
                            {
                                result2.Add(list[i]);
                            }

                            list = result2;

                        }

                        break;

                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));

        }

    }

}

