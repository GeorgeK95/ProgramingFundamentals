using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' };

            List<string> input = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> lowCase = new List<string>();
            List<string> upCase = new List<string>();
            List<string> mixCase = new List<string>();

            for (int i = 0; i < input.Count; i++)
            {
                string currWord = input[i];
                string type = GetCaseType(currWord);

                if (type.Equals("lowCase"))
                {
                    lowCase.Add(currWord);
                }
                else if (type.Equals("upCase"))
                {
                    upCase.Add(currWord);
                }
                else
                {
                    mixCase.Add(currWord);
                }
            }

            PrintResult(lowCase, upCase, mixCase);

        }

        private static void PrintResult(List<string> lowCase, List<string> upCase, List<string> mixCase)
        {
            PrintLower(lowCase);
            Console.WriteLine();
            PrintMixed(mixCase);
            Console.WriteLine();
            PrintUpper(upCase);
        }

        private static void PrintMixed(List<string> mixCase)
        {
            Console.Write("Mixed-case: ");

            for (int i = 0; i < mixCase.Count; i++)
            {
                if (i == mixCase.Count - 1)
                {
                    Console.Write(mixCase[i]);
                }
                else
                {
                    Console.Write(mixCase[i] + ", ");
                }

            }
        }

        private static void PrintUpper(List<string> upCase)
        {
            Console.Write("Upper-case: ");

            for (int i = 0; i < upCase.Count; i++)
            {
                if (i == upCase.Count - 1)
                {
                    Console.Write(upCase[i]);
                }
                else
                {
                    Console.Write(upCase[i] + ", ");
                }

            }
        }

        private static void PrintLower(List<string> lowCase)
        {
            Console.Write("Lower-case: ");

            for (int i = 0; i < lowCase.Count; i++)
            {
                if (i == lowCase.Count - 1)
                {
                    Console.Write(lowCase[i]);
                }
                else
                {
                    Console.Write(lowCase[i] + ", ");
                }

            }
        }

        private static string GetCaseType(string currWord)
        {
            string returnValue = null;

            bool low = true;
            bool up = true;
            bool mixed = true;

            for (int i = 0; i < currWord.Length; i++)
            {
                if (!IsLower(currWord[i]))
                {
                    low = false;
                }
                if (!IsUpper(currWord[i]))
                {
                    up = false;
                }

            }

            if (!low && !up)
            {
                returnValue = "mixCase";
            }
            else if (low && !up)
            {
                returnValue = "lowCase";
            }
            else
            {
                returnValue = "upCase";
            }

            return returnValue;
        }

        private static bool IsUpper(char ch)
        {
            if ((int)ch >= 65 && (int)ch <= 90)
            {
                return true;
            }

            return false;
        }

        private static bool IsLower(char ch)
        {
            if ((int)ch >= 97 && (int)ch <= 122)
            {
                return true;
            }

            return false;
        }
    }
}
