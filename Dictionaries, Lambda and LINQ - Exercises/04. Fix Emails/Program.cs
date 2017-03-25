using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();

            while (true)
            {
                string name = Console.ReadLine();
                string email = Console.ReadLine();

                if (name.Equals("stop"))
                {
                    break;
                }

                if (CheckEmail(email))
                {
                    AddToEmails(name, email, emails);
                }
            }

            Print(emails);
        }

        private static void Print(Dictionary<string, string> emails)
        {
            foreach (var pair in emails)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        private static bool CheckEmail(string email)
        {
            email = Reverse(email);
            string domaine = email[0] + "" + email[1];
            domaine = Reverse(domaine);

            if (domaine.Equals("us") || domaine.Equals("uk"))
            {
                return false;
            }

            return true;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static void AddToEmails(string name, string email, Dictionary<string, string> emails)
        {
            if (emails.ContainsKey(name))
            {
                emails[name] = email;
            }
            else
            {
                emails.Add(name, email);
            }
        }
    }
}
