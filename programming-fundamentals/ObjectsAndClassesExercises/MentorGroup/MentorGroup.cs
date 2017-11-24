using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;

namespace MentorGroup
{
    class MentorGroup
    {

        const string Format = "dd/MM/yyyy";
        static void Main(string[] args)
        {


            Dictionary<string, Student> users = AddStudentsInGroup();

            AddComments(users);

            PrintReport(users);

        }

        private static void PrintReport(Dictionary<string, Student> users)
        {
            foreach (var user in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                Console.WriteLine("Comments:");
                if (user.Value.Comments.Count > 0)
                {
                    Console.WriteLine($"- {string.Join("\n- ", user.Value.Comments)}");
                }
                Console.WriteLine("Dates attended:");
                if (user.Value.Dates.Count > 0)
                {
                    foreach (var date in user.Value.Dates.OrderBy(x => x.Date))
                    {
                        Console.WriteLine($"-- {date:dd/MM/yyyy}");
                    }
                }
            }
        }

        private static void AddComments(Dictionary<string, Student> users)
        {
            string input = Console.ReadLine();

            while (!input.Equals("end of comments"))
            {
                string[] arrInput = input.Split('-');
                string comment = arrInput[0];
                if (!users.ContainsKey(comment))
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    List<string> comments = new List<string>
                    {
                        arrInput[1]
                    };
                    users[comment].Comments.AddRange(comments);
                }

                input = Console.ReadLine();
            }
        }

        private static Dictionary<string, Student> AddStudentsInGroup()
        {
            Dictionary<string, Student> users = new Dictionary<string, Student>();
            string input = Console.ReadLine();

            while (!input.Equals("end of dates"))
            {

                string[] arrInput = input.Split(' ');

                string name = arrInput[0];

                if (!users.ContainsKey(name))
                {
                    users.Add(name, new Student());
                    users[name].Dates = new List<DateTime>();
                    users[name].Comments = new List<string>();
                    users[name].Name = name;
                }

                if (arrInput.Length < 2)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    List<DateTime> dates =
                        arrInput[1].Split(',')
                            .Select(x => DateTime.ParseExact(x, Format, CultureInfo.InvariantCulture))
                            .ToList();
                    users[name].Dates.AddRange(dates);
                }

                input = Console.ReadLine();
            }

            return users;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> Dates { get; set; }
    }
}
