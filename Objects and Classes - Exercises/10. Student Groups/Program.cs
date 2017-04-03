using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace _10.Student_Groups
{
    class Student
    {
        public string name { get; set; }
        public string email { get; set; }
        public DateTime regDate { get; set; }

        public Student()
        {

        }
        public Student(string name, string email, DateTime date)
        {
            this.name = name;
            this.email = email;
            this.regDate = date;
        }
    }
    class Town
    {
        public string name { get; set; }
        public int seats { get; set; }
        public List<Student> students { get; set; }

        public Town()
        {

        }

        public Town(string name, int seats)//, List<Student> students)
        {
            this.name = name;
            this.seats = seats;
            this.students = new List<Student>();
        }
    }
    class Group
    {
        public Town town { get; set; }
        public List<Student> students { get; set; }
        public Group()
        {

        }
        public Group(Town town, List<Student> students)
        {
            this.town = town;
            this.students = students;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = ReadInput();
            List<Group> groups = MakeGroups(towns);
            Print(towns, groups);
            //Console.WriteLine(123);
        }

        private static void Print(List<Town> towns, List<Group> groups)
        {
            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");

            foreach (var group in groups.OrderBy(x => x.town.name))
            {
                List<string> emails = new List<string>();

                foreach (var stud in group.students)
                {
                    emails.Add(stud.email.Trim());   
                }

                Console.Write($"{group.town.name} => {string.Join(", ", emails)}");
                Console.WriteLine();
            }
        }

        private static List<Group> MakeGroups(List<Town> towns)
        {
            List<Group> groups = new List<Group>();

            foreach (var town in towns.OrderBy(x => x.name))
            {
                town.students = town.students.OrderBy(x => x.regDate).ThenBy(x => x.name).ThenBy(x => x.email).ToList();
                List<Student> townStudents = town.students;
                int p = 0;

                while (p < town.students.Count)
                {
                    var hop = townStudents.Skip(p).Take(town.seats).ToList();
                    Group newGroup = new Group(town, hop);
                    groups.Add(newGroup);
                    p += town.seats;
                }
            }

            return groups;
        }

        private static List<Town> ReadInput()
        {
            List<Town> towns = new List<Town>();
            string inputLine = Console.ReadLine();

            while (!inputLine.Equals("End"))
            {
                if (inputLine.Contains("=>"))
                {
                    string[] parsed = inputLine.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    int seatsCount = int.Parse(Regex.Match(parsed[1], @"\d+").ToString());
                    Town newTown = new Town(parsed[0].Trim(), seatsCount);
                    towns.Add(newTown);
                }
                else
                {
                    string[] parsed = inputLine.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string date = GetDate(parsed[2]);
                    Student newStudent = new Student(parsed[0], parsed[1], DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture));
                    int index = towns.Count;

                    towns[index - 1].students.Add(newStudent);
                }

                inputLine = Console.ReadLine();
            }

            return towns;
        }

        private static string GetDate(string v)
        {
            string[] splitted = v.Split('-');

            if (int.Parse(splitted[0]) < 10)
            {
                splitted[0] = "0" + splitted[0].Trim();
            }

            string month = splitted[1];

            Dictionary<string, string> calendar = new Dictionary<string, string>()
            {
                { "Jan", "01" },
                { "Feb", "02" },
                { "Mar", "03" },
                { "Apr", "04" },
                { "May", "05" },
                { "Jun", "06" },
                { "Jul", "07" },
                { "Aug", "08" },
                { "Sep", "09" },
                { "Nov", "10" },
                { "Oct", "11" },
                { "Dec", "12" },
            };

            string numberMonth = calendar[splitted[1]];
            return (splitted[0] + "-" + numberMonth + "-" + splitted[2]).Trim();
        }
    }
}
