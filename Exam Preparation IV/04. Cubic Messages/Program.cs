using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line.Equals("Over!"))
                {
                    break;
                }

                int count = int.Parse(Console.ReadLine());

                if (LineIsValid(line))
                {
                    PrintMessage(line, count);
                }
            }

            //Console.WriteLine("opa");
        }

        private static void PrintMessage(string line, int count)
        {
            string message = GetMessage(line);
            List<int> digits = GetDigits(line);

            if (message.Length == count)
            {
                StringBuilder code = new StringBuilder();

                foreach (var index in digits)
                {
                    if (index >= 0 && index < message.Length)
                    {
                        code.Append(message[index]);
                    }
                    else
                    {
                        code.Append(' ');
                    }
                }

                string verificationCode = code.ToString();

                Console.WriteLine($"{message} == {verificationCode}");
            }
        }

        private static List<int> GetDigits(string line)
        {
            List<int> digits = new List<int>();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] >= 48 && line[i] <= 57)
                {
                    digits.Add(int.Parse(line[i].ToString()));
                }
            }

            return digits;
        }

        private static string GetMessage(string line)
        {
            StringBuilder sb = new StringBuilder();
            bool toWrtie = false;

            for (int i = 0; i < line.Length; i++)
            {
                if ((line[i] >= 97 && line[i] <= 122) || (line[i] >= 65 && line[i] <= 90))//ako e bukfa
                {
                    toWrtie = true;
                }
                else
                {
                    toWrtie = false;
                }

                if (toWrtie)
                {
                    sb.Append(line[i]);
                }
            }

            return sb.ToString();
        }

        private static bool LineIsValid(string line)
        {
            bool firstCheck = HasOnlyDigitsBeforeItself(line);
            bool secondCheck = AlphabetLettersAfterItself(line);

            return firstCheck && secondCheck;
        }

        private static bool AlphabetLettersAfterItself(string line)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (!(line[i] >= 48 && line[i] <= 57))
                {
                    break;
                }

                sb.Append(line[i]);
            }

            for (int i = 0; i < sb.Length; i++)
            {
                if ((sb[i] >= 97 && sb[i] <= 122) || (sb[i] >= 65 && sb[i] <= 90))
                {
                    return false;

                }
            }

            return true;
        }

        private static bool HasOnlyDigitsBeforeItself(string line)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] < 48 || line[i] > 57)
                {
                    break;
                }

                sb.Append(line[i]);
            }

            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] < 48 || sb[i] > 57)
                {
                    return false;
                }
            }

            if (sb.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}