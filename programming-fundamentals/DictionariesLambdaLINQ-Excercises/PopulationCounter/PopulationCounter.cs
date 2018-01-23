using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> populationCount = 
                new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();

            while (input != "report")
            {
                string[] inputArr = input.Split('|');
                string city = inputArr[0];
                string country = inputArr[1];
                int population = int.Parse(inputArr[2]);

                if (!populationCount.ContainsKey(country))
                {
                    populationCount[country] = new Dictionary<string, long>();
                }
                if (!populationCount[country].ContainsKey(city))
                {
                    populationCount[country].Add(city, 0);
                }
                populationCount[country][city] += population;

                input = Console.ReadLine();
            }

            Dictionary<string, long> mergingDictionary = new Dictionary<string, long>();

            foreach (var item in populationCount)
            {
                mergingDictionary[item.Key] = item.Value.Values.Sum();
            }

            foreach (var item in mergingDictionary.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} (total population: {item.Value})");
                foreach (var index in populationCount[item.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{index.Key}: {index.Value}");
                }
            }
        }
    }
}
