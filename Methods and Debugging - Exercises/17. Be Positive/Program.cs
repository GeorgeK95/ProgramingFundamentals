using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Be_Positive
{
    class Program
    {
        static List<int> results = new List<int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();

                string[] inputArray = inputLine.Trim().Split(' ');
                List<string> values = SplitStringWithNumbers(inputArray);

                TreatLineAndPrintValues(values, i);
            }


        }

        private static List<string> SplitStringWithNumbers(string[] inputArray)
        {
            List<string> str = new List<string>();

            for (int j = 0; j < inputArray.Length; j++)
            {
                if (!inputArray[j].Equals(string.Empty))
                {
                    string num = inputArray[j];
                    str.Add(num);
                }
            }

            return str;
        }

        private static void TreatLineAndPrintValues(List<string> values, int line)
        {
            bool found = false;

            for (int i = 0; i < values.Count; i++)
            {
                int currNumber1 = int.Parse(values[i]);

                if (currNumber1 >= 0)
                {
                    if (found)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(currNumber1);

                    found = true;
                }

                else if (i + 1 < values.Count)
                {
                    int currNumber2 = int.Parse(values[i + 1]);
                    int a = currNumber1 + currNumber2;

                    if (a >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(a);

                        found = true;
                    }

                    i += 1;
                }

            }

            if (!found)
            {
                Console.WriteLine("(empty)");
            }
            else
            { Console.WriteLine(); }
        }
    }
}
