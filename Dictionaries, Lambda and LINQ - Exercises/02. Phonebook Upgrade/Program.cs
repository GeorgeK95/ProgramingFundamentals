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
            string command = Console.ReadLine();
            SortedDictionary<string, string> phoneBook = new SortedDictionary<string, string>();

            while (!command.Equals("END"))
            {
                string[] splittedCommand = command.Split();

                if (splittedCommand[0].Equals("A"))
                {
                    AddContact(phoneBook, splittedCommand);
                }
                else if (splittedCommand[0].Equals("S"))
                {
                    SearchContact(phoneBook, splittedCommand);
                }
                else if (splittedCommand[0].Equals("ListAll"))
                {
                    PrintListedPhoneBook(phoneBook);
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }

                command = Console.ReadLine();
            }
        }

        private static void PrintListedPhoneBook(SortedDictionary<string, string> phoneBook)
        {
            foreach (var item in phoneBook)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        private static void SearchContact(SortedDictionary<string, string> phoneBook, string[] splittedCommand)
        {
            if (phoneBook.ContainsKey(splittedCommand[1]))
            {
                Console.WriteLine($"{splittedCommand[1]} -> {phoneBook[splittedCommand[1]]}");
            }
            else
            {
                Console.WriteLine($"Contact {splittedCommand[1]} does not exist.");
            }
        }

        private static void AddContact(SortedDictionary<string, string> phoneBook, string[] splittedCommand)
        {
            if (phoneBook.ContainsKey(splittedCommand[1]))
            {
                phoneBook[splittedCommand[1]] = splittedCommand[2];
            }
            else
            {
                phoneBook.Add(splittedCommand[1], splittedCommand[2]);
            }
        }

    }
}
