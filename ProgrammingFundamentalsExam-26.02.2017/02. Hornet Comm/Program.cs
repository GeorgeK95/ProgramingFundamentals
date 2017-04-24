using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> messages = new List<string>();
            List<string> broadcasts = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("Hornet is Green"))
                {
                    PrintResult(messages, broadcasts);
                    break;
                }

                string[] splitted = GetSplittedInput(input);

                if (IsMessage(input))
                {
                    ExecuteMessage(splitted, messages);
                }
                else if (IsBroadcast(input))
                {
                    ExecuteBroadcast(splitted, broadcasts);
                }
            }
        }

        private static void PrintResult(List<string> messages, List<string> broadcasts)
        {
            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count > 0)
            {
                foreach (var broadList in broadcasts)
                {
                    Console.WriteLine(broadList);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");

            if (messages.Count > 0)
            {
                foreach (var message in messages)
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }

        private static string[] GetSplittedInput(string input)
        {
            string value = " <-> ";
            Regex reg = new Regex(value);
            string[] splitted = reg.Split(input);
            return splitted;
        }

        private static bool IsBroadcast(string input)
        {
            string pattern = @"[^\d]+ <-> [A-Za-z\d]+";
            Regex reg = new Regex(pattern);
            string input2 = reg.Match(input).ToString();

            return input.Equals(input2);
        }

        private static bool IsMessage(string input)
        {
            string pattern = @"[\d]+ <-> [A-Za-z\d]+";
            Regex reg = new Regex(pattern);
            string input2 = reg.Match(input).ToString();

            return input.Equals(input2);
        }

        public static void ExecuteBroadcast(string[] input, List<string> broadcasts)
        {
            string message = input[0];
            string frequency = input[1];

            frequency = ChangeLetters(frequency);

            AddBroadcastToDict(message, frequency, broadcasts);
        }

        private static string ChangeLetters(string frequency)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < frequency.Length; i++)
            {
                if (frequency[i] >= 97 && frequency[i] <= 122)//low
                {
                    sb.Append(frequency[i].ToString().ToUpper());
                }
                else if (frequency[i] >= 65 && frequency[i] <= 90)//up
                {
                    sb.Append(frequency[i].ToString().ToLower());
                }
                else
                {
                    sb.Append(frequency[i]);
                }
            }

            return sb.ToString();
        }

        public static void AddBroadcastToDict(string message, string frequency, List<string> broadcasts)
        {
            var temp = new List<string>();
            broadcasts.Add(frequency + " -> " + message);
        }
        public static void ExecuteMessage(string[] input, List<string> messages)
        {
            string code = Reverse(input[0]);
            string message = input[1];

            AddMessageToDict(code, message, messages);
        }
        public static void AddMessageToDict(string code, string message, List<string> messages)
        {
            var temp = new List<string>();
            messages.Add(code + " -> " + message);
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
