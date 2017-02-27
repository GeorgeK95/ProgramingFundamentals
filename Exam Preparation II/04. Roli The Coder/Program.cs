using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Roli_The_Coder
{
    class Program
    {
         

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, string> eventIdAndName = new Dictionary<string, string>();
            Dictionary<string, List<string>> eventNameAndEventPeople = new Dictionary<string, List<string>>();

            while (!line.Equals("Time for Code"))
            {
                if (line.Contains("#"))
                {
                    string[] splitted = line.Split(new char[] { ' ', '#' }, StringSplitOptions.RemoveEmptyEntries);
                    string id = splitted[0];
                    string name = splitted[1];
                    List<string> participants = GetPeople(splitted);

                    if (!eventIdAndName.ContainsKey(id))
                    {
                        eventIdAndName.Add(id, name);
                        eventNameAndEventPeople.Add(name, participants);
                    }
                    else
                    {
                        if (eventIdAndName[id].Equals(name))
                        {
                            eventNameAndEventPeople[name].AddRange(participants);
                        }
                    }

                }

                line = Console.ReadLine();
            }

            PrintDistinctedOutput(eventNameAndEventPeople);
        }

        private static void PrintDistinctedOutput(Dictionary<string, List<string>> eventNameAndEventPeople)
        {
            foreach (var eventInfo in eventNameAndEventPeople.OrderByDescending(x => x.Value.Distinct().Count()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{eventInfo.Key} - {eventInfo.Value.Distinct().Count()}");
                foreach (var currPerson in eventInfo.Value.OrderBy(x => x).Distinct())
                {
                    Console.WriteLine($"{currPerson}");
                }
            }
        }

        private static List<string> GetPeople(string[] splitted)
        {
            List<string> temp = new List<string>();

            for (int i = 2; i < splitted.Length; i++)
            {
                temp.Add(splitted[i]);
            }

            return temp;
        }

        private static void PrintArr(string[] splitted)
        {
            foreach (var item in splitted)
            {
                Console.WriteLine(item);
            }
        }
    }
}
