using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(?:^|\s)([a-zA-Z0-9][\-\._a-zA-Z0-9]*)@[a-zA-Z\-]+(\.[a-z]+)+\b";

            MatchCollection emails = Regex.Matches(text, pattern);

            PrintEmails(emails);
        }

        private static void PrintEmails(MatchCollection emails)
        {
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}