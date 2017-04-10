using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] arr = FormatInputAndGetReadyArray(input);

            for (int i = 0; i < arr.Length; i++)
            {
                string currentTicket = arr[i];

                if (IsItInvalid(currentTicket))
                {
                    string p_1 = currentTicket.Substring(0, 10);
                    string p_2 = currentTicket.Substring(10);
                    int[] symbolContained = GetContainedSymbol(p_1, p_2);

                    switch (symbolContained[0])
                    {
                        case 1:
                            int times1 = symbolContained[1];
                            if (times1 == 10)
                            {
                                Console.WriteLine($"ticket \"{currentTicket}\" - {times1}$ Jackpot!");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{currentTicket}\" - {times1}$");
                            }

                            break;
                        case 2:
                            int times2 = symbolContained[1];
                            if (times2 == 10)
                            {
                                Console.WriteLine($"ticket \"{currentTicket}\" - {times2}@ Jackpot!");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{currentTicket}\" - {times2}@");
                            }

                            break;
                        case 3:
                            int times3 = symbolContained[1];
                            if (times3 == 10)
                            {
                                Console.WriteLine($"ticket \"{currentTicket}\" - {times3}# Jackpot!");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{currentTicket}\" - {times3}#");
                            }

                            break;
                        case 4:
                            int times4 = symbolContained[1];
                            if (times4 == 10)
                            {
                                Console.WriteLine($"ticket \"{currentTicket}\" - {times4}^ Jackpot!");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{currentTicket}\" - {times4}^");
                            }

                            break;
                        default:
                            Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }

            }

        }

        private static int[] GetContainedSymbol(string p_1, string p_2)
        {
            int[] mainArr = new int[2];
            mainArr[0] = 0;//type
            mainArr[1] = 0;//how many times
            string pattern1 = @"\${6,}";
            string pattern2 = @"\@{6,}";
            string pattern3 = @"\#{6,}";
            string pattern4 = @"\^{6,}";

            Match m1_1 = Regex.Match(p_1, pattern1);
            Match m1_2 = Regex.Match(p_2, pattern1);
            Match m2_1 = Regex.Match(p_1, pattern2);
            Match m2_2 = Regex.Match(p_2, pattern2);
            Match m3_1 = Regex.Match(p_1, pattern3);
            Match m3_2 = Regex.Match(p_2, pattern3);
            Match m4_1 = Regex.Match(p_1, pattern4);
            Match m4_2 = Regex.Match(p_2, pattern4);

            if (m1_1.Length != 0 && m1_2.Length != 0)
            {
                mainArr[0] = 1;
                mainArr[1] = Math.Min(m1_1.Length, m1_2.Length);
            }
            if (m2_1.Length != 0 && m2_2.Length != 0)
            {
                mainArr[0] = 2;
                mainArr[1] = Math.Min(m2_1.Length, m2_2.Length);
            }
            if (m3_1.Length != 0 && m3_2.Length != 0)
            {
                mainArr[0] = 3;
                mainArr[1] = Math.Min(m3_1.Length, m3_2.Length);
            }
            if (m4_1.Length != 0 && m4_2.Length != 0)
            {
                mainArr[0] = 4;
                mainArr[1] = Math.Min(m4_1.Length, m4_2.Length);
            }

            return mainArr;
        }

        private static bool IsItInvalid(string currentTicket)
        {
            if (currentTicket.Length != 20)
            {
                return false;
            }
            return true;
        }

        private static string[] FormatInputAndGetReadyArray(string input)
        {
            string[] arr = input.Split(',');

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].Trim();
            }

            return arr;
        }
    }
}
