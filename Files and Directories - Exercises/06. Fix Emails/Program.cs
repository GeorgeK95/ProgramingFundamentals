using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _06.Fix_Emails
{
    class Program
    {
        static string INPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex6\\input.txt";
        static string OUTPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex6\\output.txt";

        static void Main(string[] args)
        {

            Dictionary<string, string> emails = new Dictionary<string, string>();
            string[] inputInfo = File.ReadAllLines(INPUT_PATH);
            int index = 0;

            while (true)
            {
                string littleName = inputInfo[index];
                index++;

                if (littleName.Equals("stop"))
                {
                    break;
                }
                string email = inputInfo[index];
                index++;
                //string bigName = Console.ReadLine();
                bool isDomaineGood = GetDomaine(email);

                if (isDomaineGood)
                {
                    emails.Add(littleName, email);
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
            StringBuilder result = new StringBuilder();

            foreach (var currItem in emails)
            {
                result.Append($"{currItem.Key} -> {currItem.Value}");
                result.Append(Environment.NewLine);
            }

            File.WriteAllText(OUTPUT_PATH, result.ToString());
        }
    }
}

