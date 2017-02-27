using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Command_Interpreter
{
    class Program
    {
        static List<string> a;

        static void Main(string[] args)
        {
            /*1 2 3 4 5
sort from -1 count 2
sort from 0 count -1
reverse from 5 count 1
end*/
            a = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (!command.Equals("end"))
            {
                command = Regex.Replace(command, @"\s+", " ");

                string[] spl = command.Split(new char[] { ' ' });

                if (spl[0].Equals("reverse"))
                {
                    ExecuteReverse(spl);
                }
                else if (spl[0].Equals("sort"))
                {
                    ExecuteSort(spl);
                }
                else if (spl[0].Equals("rollRight"))
                {
                    ExecuteRollRightExecution(spl);
                }
                else if (spl[0].Equals("rollLeft"))
                {
                    ExecuteRollLeftExecution(spl);
                }
                else
                {
                    Console.WriteLine("Invalid input parameters.");
                }

                command = Console.ReadLine();
            }

            Print();
        }

        private static void ExecuteRollLeftExecution(string[] command)
        {
            int count = int.Parse(command[1]);

            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
            }

            count %= a.Count;
            for (int i = count; i > 0; i--)
            {
                string first = a.First();
                a.Remove(a.First());
                a.Add(first);
            }
        }

        private static void ExecuteRollRightExecution(string[] command)
        {
            int count = int.Parse(command[1]);
            count %= a.Count;
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            else
            {
                for (int j = 0; j < count; j++)
                {
                    string temp = a[a.Count - 1];
                    for (int i = a.Count - 1; i > 0; i--)
                    {
                        a[i] = a[i - 1];
                    }

                    a[0] = temp;
                }
            }
        }

        private static void ExecuteSort(string[] command)
        {
            int start = int.Parse(command[2]);
            int count = int.Parse(command[4]);

            if (start >= 0 && start < a.Count && count >= 0 && count + start <= a.Count && count <= a.Count)
            {
                Sort(start, count);
            }
            else
            {
                Console.WriteLine("Invalid input parameters.");
            }
        }

        private static void ExecuteReverse(string[] command)
        {
            int start = int.Parse(command[2]);
            int count = int.Parse(command[4]);

            if (start >= 0 && start < a.Count && count >= 0 && count + start <= a.Count && count <= a.Count)
            {
                Reverse(start, count);
            }
            else
            {
                Console.WriteLine("Invalid input parameters.");
            }
        }

        private static void Print()
        {
            Console.Write("[");
            Console.Write(string.Join(", ", a));
            Console.Write("]");
        }

        private static void Sort(int start, int count)
        {
            List<string> toBeSorted = a.GetRange(start, count);
            a.RemoveRange(start, count);
            toBeSorted.Sort();
            a.InsertRange(start, toBeSorted);
        }

        private static void Reverse(int start, int count)
        {
            List<string> toBeReversed = a.GetRange(start, count);
            a.RemoveRange(start, count);
            toBeReversed.Reverse();
            a.InsertRange(start, toBeReversed);
        }

    }
}
