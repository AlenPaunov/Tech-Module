using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {
            string outputPath = @"..\..\output.txt";
            File.Delete(outputPath);
           
            Random random = new Random();
            int count = int.Parse(File.ReadAllText(@"..\..\input.txt").Trim());

            List<string> phrases = new List<string>()
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            List<string> events = new List<string>()
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            List<string> authors = new List<string>() { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> cities = new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            for (int i = 0; i < count; i++)
            {
                string _phrase = phrases[GetRandom(random, phrases.Count)];
                string _event = events[GetRandom(random, events.Count)];
                string _author = authors[GetRandom(random, authors.Count)];
                string _city = cities[GetRandom(random, cities.Count)];

                File.AppendAllText(outputPath, ($"{_phrase} {_event} {_author} – {_city}.") + Environment.NewLine);
            }
        }

        public static int GetRandom(Random random, int maxValue)
        {
            int index;
            random.Next();
            index = random.Next(0, maxValue);
            return index;
        }
    }
}

