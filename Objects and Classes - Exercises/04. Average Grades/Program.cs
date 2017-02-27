using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Average_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] splitted = line.Split(' ');

                string name = splitted[0];
                double[] marks = GetMarks(splitted);

                Student stud = new Student(name, marks);

                if (stud.avg >= 5.00)
                {
                    students.Add(stud);
                }
                
            }

            PrintStudents(students);
        }

        private static void PrintStudents(List<Student> students)
        {
            students = students.OrderBy(x => x.name).ThenByDescending(x => x.avg).ToList();

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{students[i].name} -> {students[i].avg:f2}");
            }
        }

        private static double[] GetMarks(string[] splitted)
        {
            double[] grades = new double[splitted.Length];

            for (int i = 1; i < splitted.Length; i++)
            {
                grades[i] = double.Parse(splitted[i]);
            }

            return grades;
        }
    }

    class Student
    {
        public string name;
        double[] marks;
        public double avg;

        public Student(string name, double[] marks)
        {
            this.name = name;
            this.marks = marks;
            this.avg = GetAverage(marks);
        }

        private double GetAverage(double[] marks)
        {
            double sum = 0;

            for (int i = 1; i < marks.Length; i++)
            {
                sum += marks[i];
            }

            return sum / (marks.Length - 1);
        }
    }
}
