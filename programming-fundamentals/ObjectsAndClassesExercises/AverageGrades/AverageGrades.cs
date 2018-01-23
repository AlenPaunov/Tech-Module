using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
    class AverageGrades
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> studentsList = Student.ReadStudents(studentsCount);
            studentsList = studentsList.OrderBy(x => x.Name).ThenBy(x => -x.AverageGrade).ToList();

            Student.PrintStudentList(studentsList, 5.00);
        }
    }

    public class Student
    {
        public string Name;
        public List<double> Grades;
        public double AverageGrade;

        public Student()
        {
        }

        public Student(string name, List<double> grades)
        {
            Name = name;
            Grades = grades;
            AverageGrade = grades.Sum() / grades.Count;
        }

        public static List<Student> ReadStudents(int count)
        {
            List<Student> studentsList = new List<Student>();
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, 2).ToArray();
                string name = input[0];
                List<double> grades = input[1]
                    .Split(' ')
                    .Select(x => double.Parse(x))
                    .ToList();

                Student student = new Student(name, grades);
                studentsList.Add(student);
            }
            return studentsList;
        }
        public static void PrintStudentList(List<Student> studentsList, double averageGrade)
        {
            foreach (var student in studentsList)
            {
                if (student.AverageGrade >= averageGrade)
                {
                    Console.WriteLine($"{student.Name} -> {student.AverageGrade.ToString("f2")}");
                }
            }
        }
    }
}
