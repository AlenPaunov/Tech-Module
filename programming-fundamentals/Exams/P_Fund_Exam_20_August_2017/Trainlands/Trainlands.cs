using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainlands
{
    class Trainlands
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> trains = new Dictionary<string, Dictionary<string, long>>();

            string line = Console.ReadLine();

            while (line != "It's Training Men!")
            {
                if (line.Contains(" -> "))
                {
                    string[] tokens = line.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    string trainName = tokens[0];

                    if (tokens[1].Contains(" : "))
                    {
                        string[] wagonTokens = tokens[1].Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries);
                        string wagonName = wagonTokens[0];
                        long wagonPower = long.Parse(wagonTokens[1]);

                        if (!trains.ContainsKey(trainName))
                        {
                            trains.Add(trainName, new Dictionary<string, long> { [wagonName] = wagonPower });
                        }
                        else
                        {
                            if (!trains[trainName].ContainsKey(wagonName))
                            {
                                trains[trainName].Add(wagonName, wagonPower);
                            }
                            else
                            {
                                trains[trainName][wagonName] += wagonPower;
                            }
                        }
                    }
                    else
                    {
                        string otherTrain = tokens[1];
                        if (otherTrain != trainName)
                        {
                            if (!trains.ContainsKey(trainName))
                            {
                                trains.Add(trainName, new Dictionary<string, long>());
                            }

                            foreach (var wagon in trains[otherTrain])
                            {
                                trains[trainName].Add(wagon.Key, wagon.Value);
                            }
                            trains.Remove(otherTrain);
                        }
                    }

                }
                else
                {
                    string[] tokens = line.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);
                    string train = tokens[0];
                    string otherTrain = tokens[1];

                    if (otherTrain != train)
                    {
                        if (!trains.ContainsKey(train))
                        {
                            trains.Add(train, new Dictionary<string, long>());
                        }


                        trains[train].Clear();

                        foreach (var wagon in trains[otherTrain])
                        {
                            trains[train].Add(wagon.Key, wagon.Value);
                        }
                    }

                }

                line = Console.ReadLine();
            }

            var ordered = trains.OrderByDescending(x => x.Value.Sum(a => a.Value)).ThenBy(t => t.Value.Count);

            foreach (var train in ordered)
            {
                Console.WriteLine($"Train: {train.Key}");
                foreach (var wagon in train.Value.OrderByDescending(w => w.Value)) 
                {
                    Console.WriteLine($"###{wagon.Key} - {wagon.Value}");
                }
            }
        }
    }
}
