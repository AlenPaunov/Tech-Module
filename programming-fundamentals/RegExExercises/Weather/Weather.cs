using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Weather
{
    class Weather
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<name>[A-Z]{2})(?<temperature>\d+\.{1}\d*)(?<weather>[a-zA-z]+)(?=\|)";

            Regex regex = new Regex(pattern);
            List<City> cities = new List<City>();

            while (true)
            {

                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                if (regex.IsMatch(command))
                {
                    City city = new City(regex.Match(command));

                    if (cities.Any(x => x.Name == city.Name))
                    {
                        City existingCity = cities.First(x => x.Name == city.Name);
                        existingCity.Temperature = city.Temperature;
                        existingCity.Weather = city.Weather;
                    }
                    else
                    {
                        cities.Add(city);
                    }
                }
            }
            cities = cities.OrderBy(x => x.Temperature).ToList();

            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Name} => {city.Temperature.ToString("f2")} => {city.Weather}");
            }
        }
    }
    class City
    {
        public string Name;
        public float Temperature;
        public string Weather;

        public City(Match match)
        {
            Name = match.Groups["name"].Value;
            Temperature = float.Parse(match.Groups["temperature"].Value);
            Weather = match.Groups["weather"].Value;
        }
    }
}
