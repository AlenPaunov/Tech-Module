using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AverageGrades
{
    class AverageGrades
    {
        static void Main(string[] args)
        {
            string outputPath = @"..\..\output.txt";
            File.Delete(outputPath);

            string[] input = File.ReadAllLines(@"..\..\input.txt");
            int studentsCount = int.Parse(input[0]);
            List<Student> studentsList = Student.ReadStudents(studentsCount, input);
            studentsList = studentsList.OrderBy(x => x.Name).ThenBy(x => -x.AverageGrade).ToList();

            Student.PrintStudentList(studentsList, 5.00, outputPath);
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

        public static List<Student> ReadStudents(int count, string[] input)
        {
            List<Student> studentsList = new List<Student>();
            for (int i = 0; i < count; i++)
            {
                string[] data = input[i + 1].Split(new char[] { ' ' }, 2).ToArray();
                string name = data[0];
                List<double> grades = data[1]
                    .Split(' ')
                    .Select(x => double.Parse(x))
                    .ToList();

                Student student = new Student(name, grades);
                studentsList.Add(student);
            }
            return studentsList;
        }
        public static void PrintStudentList(List<Student> studentsList, double averageGrade, string outputPath)
        {
            foreach (var student in studentsList)
            {
                if (student.AverageGrade >= averageGrade)
                {
                    File.AppendAllText(outputPath, ($"{student.Name} -> {student.AverageGrade.ToString("f2")}") + Environment.NewLine);
                }
            }
        }
    }
}