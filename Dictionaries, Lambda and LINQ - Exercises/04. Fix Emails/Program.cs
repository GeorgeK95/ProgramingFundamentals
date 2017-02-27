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
                string littleName = Console.ReadLine();
                string email = Console.ReadLine();
                //string bigName = Console.ReadLine();

                if (!littleName.Equals("stop"))
                {
                    bool isDomaineGood = GetDomaine(email);

                    if (isDomaineGood)
                    {
                        emails.Add(littleName, email);
                    }
                }
                else
                {
                    break;
                }
            }

            PrintEmails(emails);
        }

        private static bool GetDomaine(string email)
        {
            string domaine = "";

            for (int i = email.Length; i > email.Length - 2; i--)
            {
                domaine += email[i - 1];
            }

            Reverse(domaine);

            if (!domaine.Equals("us") || !domaine.Equals("uk"))
            {
                return true;
            }

            return false;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static void PrintEmails(Dictionary<string, string> emails)
        {
            foreach (var currItem in emails)
            {
                Console.WriteLine($"{currItem.Key} -> {currItem.Value}");
            }
        }
    }
}
