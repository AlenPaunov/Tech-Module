using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftUni_Karaoke
{
    class SoftUni_Karaoke
    {
        static void Main(string[] args)
        {
            {
                List<string> participants = Console.ReadLine().Split(new char[] { ',', ' ' },
                   StringSplitOptions.RemoveEmptyEntries)
                   .ToList();
                List<string> songs = Console.ReadLine().Split(new string[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string[] awards = Console.ReadLine().Split(new string[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Dictionary<string, SortedSet<string>> dict =
                    new Dictionary<string, SortedSet<string>>();


                while (awards[0] != "dawn")
                {
                    string participant = awards[0];
                    string song = awards[1];
                    string award = awards[2];

                    if (participants.Contains(participant) && songs.Contains(song))
                    {
                        if (!dict.ContainsKey(participant))
                        {
                            dict.Add(participant, new SortedSet<string>());
                        }

                        if (!dict[participant].Contains(award))
                        {
                            dict[participant].Add(award);
                        }

                    }
                    awards = Console.ReadLine().Split(new string[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                }

                if (dict.Count < 1)
                {
                    Console.WriteLine("No awards");
                }
                else
                {

                    foreach (var item in dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                    {
                        var items = item.Value;

                        if (item.Value.Count > 0)
                        {
                            Console.WriteLine(item.Key + ": " + items.Count + " awards");
                        }

                        foreach (var l in items)
                        {
                            Console.WriteLine("--" + l);
                        }
                    }
                }
            }
        }
    }
    class Participant
    {
        public string Name;
        public Dictionary<string, Song> Awards;

        public Participant(string name)
        {
            Name = name;
            Awards = new Dictionary<string, Song>();
        }

        public static Participant Parse(string name)
        {
            Participant participant = new Participant(name);
            return participant;
        }
    }
    class Song
    {
        public string Singer;
        public string Name;

        public Song(string[] tokens)
        {
            Singer = tokens[0];
            Name = tokens[1];
        }
        public Song()
        {

        }
        public Song(string singer, string name)
        {
            Name = name;
            Singer = singer;
        }

        public static Song Parse(string[] tokens)
        {
            Song song = new Song(tokens);
            return song;
        }
    }
}
