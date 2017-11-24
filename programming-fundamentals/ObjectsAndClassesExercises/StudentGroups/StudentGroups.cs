using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroups
{
    class StudentGroups
    {
        static void Main(string[] args)
        {

            List<Town> towns = new List<Town>();
            ReadTownsAndStudents(towns);
            List<Group> groups = DistributeStudentsIntoGroups(towns);
            PrintGroups(groups, towns);

        }

        public static void ReadTownsAndStudents(List<Town> towns)
        {
            string currentTownName = "";
            while (true)
            {   
                
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                if (input.Contains("=>"))
                    {
                    string[] townInfo = input.Split(new string[] { "=>" }, StringSplitOptions.None);
                    string[] seatsInfo = townInfo[1].Trim().Split(' ');
                    Town town = new Town()
                    {
                        Name = townInfo[0].Trim(),
                        SeatsCount = int.Parse(seatsInfo[0]),
                        Students = new List<Student>()
                    };

                    towns.Add(town);
                    currentTownName = town.Name;
                }
                else
                {
                    string[] studentInfo = input.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    Student student = new Student()
                    {
                        Name = studentInfo[0].Trim(),
                        Email = studentInfo[1].Trim(),
                        RegistrationDate = DateTime.ParseExact(studentInfo[2].Trim(), "d-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture)
                    };

                    Town existingTown = towns.First(t => t.Name == currentTownName);
                    existingTown.Students.Add(student);
                }
            }
        }

        public static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            List<Group> groups = new List<Group>();

            foreach (var town in towns)
            {
                IEnumerable<Student> students = town.Students
                    .OrderBy(s => s.RegistrationDate)
                    .ThenBy(s => s.Name)
                    .ThenBy(s => s.Email);

                while (students.Any())
                {
                    Group group = new Group()
                    {
                        Town = town,
                    };
                    group.Students = students.Take(group.Town.SeatsCount).ToList();
                    students = students.Skip(group.Town.SeatsCount);
                    groups.Add(group);
                }
            }
            return groups;
        }

        public static void PrintGroups(List<Group> groups, List<Town> towns)
        {
            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");
           
            foreach (Group group in groups.OrderBy(g => g.Town.Name))
            {
                Console.WriteLine($"{group.Town.Name} => {string.Join(", ",group.Students.Select(s=>s.Email.ToString()).ToArray())}");
            }
        }
    }

    class Student
    {
        public string Name;
        public string Email;
        public DateTime RegistrationDate;
    }

    class Town
    {
        public string Name;
        public int SeatsCount;
        public List<Student> Students;


    }

    class Group
    {
        public Town Town;
        public List<Student> Students;
    }
}
