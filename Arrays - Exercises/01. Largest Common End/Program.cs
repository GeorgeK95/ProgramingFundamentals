using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            string[] numbers1 = line1.Split(' ');
            string[] numbers2 = line2.Split(' ');

            int start = 0;
            int end = 0;

            start = GetStart(numbers1, numbers2);
            end = GetEnd(numbers1, numbers2);

            Console.WriteLine(Math.Max(start, end));
        }

        private static int GetEnd(string[] numbers1, string[] numbers2)
        {
            int end = 0;
            int diff = Math.Abs(numbers1.Length - numbers2.Length);

            if (numbers1.Length >= numbers2.Length)
            {
                for (int i = numbers2.Length - 1; i >= 0; i--)
                {
                    if (numbers1[i + diff].Equals(numbers2[i]))
                    {
                        end++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = numbers1.Length - 1; i >= 0; i--)
                {
                    if (numbers1[i].Equals(numbers2[i + diff]))
                    {
                        end++;
                    }
                    else
                    {
                        break;
                    }
                }
            }


            return end;
        }

        private static int GetStart(string[] numbers1, string[] numbers2)
        {
            int start = 0;

            if (numbers1.Length > numbers2.Length)
            {
                for (int i = 0; i < numbers2.Length; i++)
                {
                    if (numbers2[i].Equals(numbers1[i]))
                    {
                        start++;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            else
            {
                for (int i = 0; i < numbers1.Length; i++)
                {
                    if (numbers2[i].Equals(numbers1[i]))
                    {
                        start++;
                    }
                    else
                    {
                        break;
                    }
                }
            }


            return start;
        }
    }
}
