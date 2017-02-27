using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _08.Average_Grades
{
    class Program
    {
        static string INPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex8\\input.txt";
        static string OUTPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex8\\output.txt";

        static void Main(string[] args)
        {
            string[] inputInfo = GetInput();
            int n = int.Parse(inputInfo[0]);
            int index = 0;
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string line = inputInfo[index];
                index++;
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

        private static string[] GetInput()
        {
            string[] inputInfo = File.ReadAllText(INPUT_PATH).Split('\n');
            inputInfo = RemoveNewLineChars(inputInfo);
            return inputInfo;
        }

        private static string[] RemoveNewLineChars(string[] inputInfo)
        {
            for (int i = 0; i < inputInfo.Length; i++)
            {
                inputInfo[i] = inputInfo[i].Replace("\r", "");
            }

            return inputInfo;
        }

        private static void PrintStudents(List<Student> students)
        {
            students = students.OrderBy(x => x.name).ThenByDescending(x => x.avg).ToList();
            StringBuilder results = new StringBuilder();

            for (int i = 0; i < students.Count; i++)
            {
                results.Append($"{students[i].name} -> {students[i].avg:f2}");
                results.Append(Environment.NewLine);
            }

            File.WriteAllText(OUTPUT_PATH, results.ToString());
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

