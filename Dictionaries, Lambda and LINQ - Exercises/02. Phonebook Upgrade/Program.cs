using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Phonebook_Upgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            while (true)
            {
                string[] arrayPhonebookCommands = Console.ReadLine().Split(' ').ToArray();
                string command = arrayPhonebookCommands[0];

                if (command.Equals("END"))
                {
                    break;
                }

                switch (command)
                {
                    case "A":
                        AddContactToPhoneBook(phoneBook, arrayPhonebookCommands);
                        break;
                    case "S":
                        SearchContactToPhoneBook(phoneBook, arrayPhonebookCommands);
                        break;
                    case "ListAll":
                        PrintListedPhoneBook(phoneBook);
                        break;
                }
            }
        }

        private static void PrintListedPhoneBook(Dictionary<string, string> phoneBook)
        {
            var list = phoneBook.Keys.ToList();
            list.Sort();

            foreach (var key in list)
            {
                Console.WriteLine("{0} -> {1}", key, phoneBook[key]);
            }
        }

        private static void SearchContactToPhoneBook(Dictionary<string, string> phoneBook, string[] arrayPhonebookCommands)
        {
            string nameSearch = arrayPhonebookCommands[1];

            if (phoneBook.ContainsKey(nameSearch))
            {
                Console.WriteLine($"{nameSearch} -> {phoneBook[nameSearch]}");
            }
            else
            {
                Console.WriteLine($"Contact {nameSearch} does not exist.");
            }
        }

        private static void AddContactToPhoneBook(Dictionary<string, string> phoneBook, string[] arrayPhonebookCommands)
        {
            string nameAdd = arrayPhonebookCommands[1];
            string telNum = arrayPhonebookCommands[2];

            if (!phoneBook.ContainsKey(nameAdd))
            {
                phoneBook.Add(nameAdd, telNum);
            }
            else
            {
                phoneBook[nameAdd] = telNum;
            }
        }
    }
}

