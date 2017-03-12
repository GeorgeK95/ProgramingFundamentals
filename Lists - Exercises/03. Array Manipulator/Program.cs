using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (!command.Equals("print"))
            {
                string[] splittedCommand = command.Split(' ');

                if (splittedCommand[0].Equals("add"))
                {
                    ExecuteAddCommand(splittedCommand, numbers);
                }
                else if (splittedCommand[0].Equals("addMany"))
                {
                    ExecuteAddManyCommand(splittedCommand, numbers);
                }
                else if (splittedCommand[0].Equals("contains"))
                {
                    int index = ExecuteContains(splittedCommand, numbers);
                    Console.WriteLine(index);
                }
                else if (splittedCommand[0].Equals("remove"))
                {
                    numbers.RemoveAt(int.Parse(splittedCommand[1]));
                }
                else if (splittedCommand[0].Equals("shift"))
                {
                    ExecuteShift(int.Parse(splittedCommand[1]), numbers);
                }
                else if (splittedCommand[0].Equals("sumPairs"))
                {
                    numbers = ExecuteSumPairs(numbers);
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }

                command = Console.ReadLine();
            }

            Print(numbers);
        }

        private static void Print(List<int> numbers)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", numbers));
            Console.Write("]");
        }

        public static List<int> ExecuteSumPairs(List<int> numbers)
        {
            List<int> temp = new List<int>();

            for (int i = 0; i < numbers.Count; i += 2)
            {
                int first = numbers[i];
                int second = 0;

                if (i != numbers.Count - 1)
                {
                    second = numbers[i + 1];
                }

                temp.Add(first + second);
            }

            return temp;
        }

        private static void ExecuteShift(int count, List<int> numbers)
        {
            count %= numbers.Count;
            List<int> temp = new List<int>();

            for (int i = 0; i < count; i++)
            {
                temp.Add(numbers[0]);
                numbers.RemoveAt(0);
            }

            for (int i = 0; i < temp.Count; i++)
            {
                numbers.Add(temp[i]);
            }

        }

        private static int ExecuteContains(string[] splittedCommand, List<int> numbers)
        {
            int index = -1;
            int searchedElement = int.Parse(splittedCommand[1]);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == searchedElement)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private static void ExecuteAddManyCommand(string[] splittedCommand, List<int> numbers)
        {
            int index = int.Parse(splittedCommand[1]);
            List<int> numberToBeAdded = new List<int>();

            for (int i = 2; i < splittedCommand.Length; i++)
            {
                numberToBeAdded.Add(int.Parse(splittedCommand[i]));
            }

            numbers.InsertRange(index, numberToBeAdded);
        }

        private static void ExecuteAddCommand(string[] splittedCommand, List<int> numbers)
        {
            int index = int.Parse(splittedCommand[1]);
            int numberToBeAdded = int.Parse(splittedCommand[2]);

            numbers.Insert(index, numberToBeAdded);
        }
    }
}

