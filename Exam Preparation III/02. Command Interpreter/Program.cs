using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Command_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = GetArray();

            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("end"))
                {
                    PrintArray(arr);
                    break;
                }

                if (IsValid(command, arr.Length, arr))
                {
                    arr = PerformAction(arr, command);
                }
                else
                {
                    Console.WriteLine("Invalid input parameters.");
                }
            }
        }

        private static void PrintArray(string[] arr)
        {
            Console.Write('[');
            Console.Write(string.Join(", ", arr));
            Console.WriteLine(']');
        }

        private static string[] PerformAction(string[] arr, string command)
        {
            if (command.Split()[0].Equals("reverse"))
            {
                PerformReverse(arr, command);
            }
            else if (command.Split()[0].Equals("sort"))
            {
                PerformSort(arr, command);
            }
            else if (command.Split()[0].Equals("rollLeft"))
            {
                arr = PerformRollLeft(arr, command);
            }
            else if (command.Split()[0].Equals("rollRight"))
            {
                arr = PerformRollRight(arr, command);
            }
            else
            {
                Console.WriteLine("No Match");
            }

            return arr;
        }

        private static string[] PerformRollRight(string[] arr, string command)
        {
            int count = GetRollCount(command) % arr.Length;
            List<string> arrList = arr.ToList();

            for (int i = 0; i < count; i++)
            {
                string a = arrList.Last();
                int indexToRemove = arrList.LastIndexOf(a);
                arrList.RemoveAt(indexToRemove);
                arrList.Insert(0, a);
            }

            return arrList.ToArray();
        }

        private static string[] PerformRollLeft(string[] arr, string command)
        {
            int count = GetRollCount(command) % arr.Length;
            List<string> arrList = arr.ToList();

            for (int i = 0; i < count; i++)
            {
                string a = arrList.First();
                arrList.Remove(arrList.First());
                arrList.Add(a);
            }

            return arrList.ToArray();
        }

        private static int GetRollCount(string command)
        {
            string[] splittedCommand = command.Split();
            return int.Parse(splittedCommand[1]);
        }

        private static void PerformSort(string[] arr, string command)
        {
            int start = GetStartIndex(command);
            int count = GetCount(command);

            string[] toSort = arr.Skip(start).Take(count).ToArray();
            Array.Sort(toSort);
            int j = 0;

            for (int i = start; i < count + start; i++)
            {
                arr[i] = toSort[j];
                j++;
            }
        }

        private static void PerformReverse(string[] arr, string command)
        {
            int start = GetStartIndex(command);
            int count = GetCount(command);

            string[] toReverse = arr.Skip(start).Take(count).ToArray();
            toReverse = toReverse.Reverse().ToArray();
            int j = 0;

            for (int i = start; i < count + start; i++)
            {
                arr[i] = toReverse[j];
                j++;
            }
        }
        private static int GetCount(string command)
        {
            string[] splittedCommand = command.Split();
            return int.Parse(splittedCommand[4]);
        }

        private static int GetStartIndex(string command)
        {
            string[] splittedCommand = command.Split();
            return int.Parse(splittedCommand[2]);
        }

        private static bool IsValid(string command, int n, string[] a)
        {
            if (command.Split()[0].Equals("reverse") || command.Split()[0].Equals("sort"))
            {
                int start = GetStartIndex(command);
                int count = GetCount(command);

                if (start < 0 || start >= n)
                {
                    return false;
                }
                if (start + count > n || count < 0)
                {
                    return false;
                }

            }
            else
            {
                int count = GetRollCount(command);

                if (count < 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static string[] GetArray()
        {
            return Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
