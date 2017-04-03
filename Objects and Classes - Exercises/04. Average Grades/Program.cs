using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Average_Grades
{
    class Student
    {
        public double grade{ get; set; }
        public string name { get; set; }

        public Student(double grade, string name)
        {
            this.grade = grade;
            this.name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                string name = studentInfo[0];
                List<double> grades = new List<double>();

                MakeStudents(grades, studentInfo, name, students);
            }

            PrintStudents(students);
        }

        private static void PrintStudents(List<Student> students)
        {
            foreach (var student in students.OrderBy(x=>x.name).ThenByDescending(x=>x.grade))
            {
                Console.WriteLine($"{student.name} -> {student.grade:F2}");
            }
        }

        private static void MakeStudents(List<double> grades, string[] studentInfo, string name, List<Student> students)
        {
            for (int j = 1; j < studentInfo.Length; j++)
            {
                grades.Add(double.Parse(studentInfo[j]));
            }

            double avgGrade = grades.Average();

            if (avgGrade >= 5)
            {
                Student student = new Student(avgGrade, name);
                students.Add(student);
            }
        }

    }
}
