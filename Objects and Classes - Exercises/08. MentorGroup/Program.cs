using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace _08.MentorGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<DateTime>> nameDate = new SortedDictionary<string, List<DateTime>>();
            Dictionary<string, List<string>> nameComments = new Dictionary<string, List<string>>();

            while (true)
            {
                string dateInput = Console.ReadLine();

                if (dateInput.Equals("end of dates"))
                {
                    break;
                }

                string name = GetDateName(dateInput);
                List<DateTime> datesList = GetDates(dateInput);

                AddInfoToDict(name, datesList, nameDate);

            }

            while (true)
            {
                string commentsInput = Console.ReadLine();

                if (commentsInput.Equals("end of comments"))
                {
                    break;
                }

                string name = GetCommentName(commentsInput);
                string comment = GetComment(commentsInput);

                AddInfoToCommentsDict(name, comment, nameComments, nameDate);
            }

            Print(nameDate, nameComments);
        }

        private static void Print(SortedDictionary<string, List<DateTime>> nameDate, Dictionary<string, List<string>> nameComments)
        {
            foreach (var namDat in nameDate)
            {
                Console.WriteLine(namDat.Key);
                Console.WriteLine("Comments: ");

                if (nameComments.ContainsKey(namDat.Key))
                {
                    foreach (var comment in nameComments[namDat.Key])
                    {
                        Console.WriteLine($"- {comment}");
                    }
                }

                Console.WriteLine("Dates attended: ");
                
                foreach (var date in nameDate[namDat.Key].OrderBy(x => x))
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy")}");
                }
            }
        }

        private static string GetComment(string commentsInput)
        {
            return commentsInput.Split('-')[1];
        }

        private static string GetCommentName(string commentsInput)
        {
            return commentsInput.Split('-')[0];
        }

        private static List<DateTime> GetDates(string dateInput)
        {
            List<DateTime> dates = new List<DateTime>();
            string[] splittedInput = dateInput.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < splittedInput.Length; i++)
            {
                DateTime date = DateTime.ParseExact(splittedInput[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dates.Add(date);
            }

            return dates;
        }

        private static string GetDateName(string dateInput)
        {
            return dateInput.Split()[0];
        }

        private static void AddInfoToCommentsDict(string name, string comment, Dictionary<string, List<string>> nameComments, SortedDictionary<string, List<DateTime>> nameDate)
        {
            if (nameDate.ContainsKey(name))
            {
                List<string> temp = new List<string>();

                if (nameComments.ContainsKey(name))
                {
                    temp = nameComments[name];
                }

                temp.Add(comment);
                nameComments[name] = temp;
            }
        }

        private static void AddInfoToDict(string name, List<DateTime> datesList, SortedDictionary<string, List<DateTime>> nameDate)
        {
            List<DateTime> temp = new List<DateTime>();

            if (nameDate.ContainsKey(name))
            {
                temp = nameDate[name];
                temp.AddRange(datesList);
            }
            else
            {
                temp.AddRange(datesList);
            }

            nameDate[name] = temp;
        }

    }
}
