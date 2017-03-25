using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

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
                else
                {
                    Console.WriteLine("Invalid command");
                }

                command = Console.ReadLine();
            }
        }

        private static void SearchContact(Dictionary<string, string> phoneBook, string[] splittedCommand)
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

        private static void AddContact(Dictionary<string, string> phoneBook, string[] splittedCommand)
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
