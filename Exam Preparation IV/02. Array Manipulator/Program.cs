using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = GetArray();

            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("end"))
                {
                    Print(arr);
                    break;
                }

                ExecuteCommand(arr, command);
            }
        }

        private static void Print(List<int> arr)
        {
            Console.Write('[');
            Console.Write(string.Join(", ", arr));
            Console.Write(']');
        }

        private static void ExecuteCommand(List<int> arr, string command)
        {
            string firstWord = command.Split()[0];

            if (firstWord.Equals("exchange"))
            {
                ExecuteExchange(arr, command);
            }
            else if (firstWord.Equals("max"))
            {
                string secondWord = command.Split()[1];

                if (secondWord.Equals("odd"))
                {
                    ExecuteMaxOdd(arr);
                }
                else
                {
                    ExecuteMaxEven(arr);

                }
            }
            else if (firstWord.Equals("min"))
            {
                string secondWord = command.Split()[1];

                if (secondWord.Equals("odd"))
                {
                    ExecuteMinOdd(arr);
                }
                else
                {
                    ExecuteMinEven(arr);

                }
            }
            else if (firstWord.Equals("first"))
            {
                int count = int.Parse(command.Split()[1]);
                string secondWord = command.Split()[2];

                if (secondWord.Equals("odd"))
                {
                    ExecuteFirstOdd(arr, count);
                }
                else
                {
                    ExecuteFirstEven(arr, count);
                }
            }
            else if (firstWord.Equals("last"))
            {
                int count = int.Parse(command.Split()[1]);
                string secondWord = command.Split()[2];

                if (secondWord.Equals("odd"))
                {
                    ExecuteLastOdd(arr, count);
                }          
                else       
                {          
                    ExecuteLastEven(arr, count);
                }
            }
        }

        private static void ExecuteLastEven(List<int> arr, int count)
        {
            if (count > arr.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                List<int> first = arr;
                first.Reverse();
                first = first.Where(x => x % 2 == 0).Take(count).ToList();

                first.Reverse();
                arr.Reverse();
                Console.Write('[');
                Console.Write(string.Join(", ", first));
                Console.WriteLine(']');
            }
        }

        private static void ExecuteLastOdd(List<int> arr, int count)
        {
            if (count > arr.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                List<int> first = arr;
                first.Reverse();
                first = first.Where(x => x % 2 == 1).Take(count).ToList();

                first.Reverse();
                arr.Reverse();
                Console.Write('[');
                Console.Write(string.Join(", ", first));
                Console.WriteLine(']');
            }
        }

        private static void ExecuteFirstEven(List<int> arr, int count)
        {
            if (count > arr.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                List<int> first = arr.Where(x => x % 2 == 0).Take(count).ToList();

                Console.Write('[');
                Console.Write(string.Join(", ", first));
                Console.WriteLine(']');
            }
        }

        private static void ExecuteFirstOdd(List<int> arr, int count)
        {
            if (count > arr.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                List<int> first = arr.Where(x => x % 2 == 1).Take(count).ToList();

                Console.Write('[');
                Console.Write(string.Join(", ", first));
                Console.WriteLine(']');
            }
        }

        private static void ExecuteMinEven(List<int> arr)
        {
            int index = 0;
            int min = int.MaxValue;
            bool found = false;

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] <= min && arr[i] % 2 == 0)
                {
                    min = arr[i];
                    index = i;
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static void ExecuteMinOdd(List<int> arr)
        {
            int index = 0;
            int min = int.MaxValue;
            bool found = false;

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] <= min && arr[i] % 2 == 1)
                {
                    min = arr[i];
                    index = i;
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static void ExecuteMaxEven(List<int> arr)
        {
            int index = 0;
            int max = int.MinValue;
            bool found = false;

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] >= max && arr[i] % 2 == 0)
                {
                    max = arr[i];
                    index = i;
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static void ExecuteMaxOdd(List<int> arr)
        {
            int index = 0;
            int max = int.MinValue;
            bool found = false;

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] >= max && arr[i] % 2 == 1)
                {
                    max = arr[i];
                    index = i;
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static void ExecuteExchange(List<int> arr, string command)
        {
            int index = int.Parse(command.Split()[1]);

            if (index < 0 || index >= arr.Count)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                List<int> partArr = arr.Take(index + 1).ToList();
                arr.RemoveRange(0, index + 1);
                arr.AddRange(partArr);
            }
        }

        private static List<int> GetArray()
        {
            string input = Console.ReadLine();
            return input.Split().Select(int.Parse).ToList();
        }
    }
}
