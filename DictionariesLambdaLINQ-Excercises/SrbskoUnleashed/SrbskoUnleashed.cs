using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrbskoUnleashed
{
    class SrbskoUnleashed
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> VenueSignerAndTotalMoney = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "End") break;
                string[] inputData = text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                //Check input
                string[] checkData = text.Split(new char[] { ' ', '@' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (inputData.Length != checkData.Length) continue;

                int indexSign = 0;
                //Check where is '@' sign
                indexSign = DefineIndexPossition(inputData, indexSign);

                //Check Singer Name
                if (indexSign <= 1 || indexSign >= 5) continue;
                if (inputData.Length - indexSign >= 5 || inputData.Length - indexSign < 2) continue;

                //Define Singer Name
                string singerName = DefineSignerName(inputData, indexSign);

                //Check ticketsPrice and ticketsCount
                int ticketsPrice;
                int ticketsCount;
                try
                {
                    ticketsPrice = int.Parse(inputData[inputData.Length - 2]);
                    ticketsCount = int.Parse(inputData[inputData.Length - 1]);
                }
                catch
                {
                    continue;
                }

                //Define venue
                string venue = DefineVenue(checkData, indexSign);
                long currentAmountOfMoney = (long)ticketsPrice * ticketsCount;
                DefineDictionary(VenueSignerAndTotalMoney, singerName, venue, currentAmountOfMoney);
            }
            PrintDictionary(VenueSignerAndTotalMoney);
        }

        private static void DefineDictionary(Dictionary<string, Dictionary<string, long>> VenueSignerAndTotalMoney, string singerName, string vanue, long currentMoneyAmounth)
        {
            if (VenueSignerAndTotalMoney.ContainsKey(vanue))
            {
                Dictionary<string, long> CurrentVanue = VenueSignerAndTotalMoney[vanue];
                if (CurrentVanue.ContainsKey(singerName))
                {
                    CurrentVanue[singerName] += currentMoneyAmounth;
                }
                else CurrentVanue[singerName] = currentMoneyAmounth;
            }
            else
            {
                Dictionary<string, long> newVenue = new Dictionary<string, long>
                {
                    [singerName] = currentMoneyAmounth
                };
                VenueSignerAndTotalMoney.Add(vanue, newVenue);
            }
        }

        private static void PrintDictionary(Dictionary<string, Dictionary<string, long>> VanueSignerAndTotalMoney)
        {
            foreach (var pair in VanueSignerAndTotalMoney)
            {
                Console.WriteLine(pair.Key);
                var OrderedSignerAndTotalMoney = pair.Value.OrderByDescending(i => i.Value);
                foreach (var value in OrderedSignerAndTotalMoney)
                {
                    Console.WriteLine($"#  {value.Key} -> {value.Value}");
                }
            }
        }

        private static string DefineVenue(string[] checkData, int indexSign)
        {
            string[] vanues = new string[checkData.Length - indexSign];
            for (int i = indexSign - 1; i < checkData.Length - 2; i++)
            {
                vanues[i - indexSign + 1] = checkData[i];
            }
            string vanue = string.Join(" ", vanues);
            return vanue;
        }

        private static string DefineSignerName(string[] inputData, int indexSign)
        {
            string[] singerNameData = new string[indexSign - 1];
            for (int i = 0; i < indexSign - 1; i++)
            {
                singerNameData[i] = inputData[i];
            }
            string singerName = string.Join(" ", singerNameData);
            return singerName;
        }

        private static int DefineIndexPossition(string[] inputData, int indexSign)
        {
            foreach (var a in inputData)
            {
                indexSign++;
                if (a.Contains('@')) break;
            }
            return indexSign;
        }
    }
}
