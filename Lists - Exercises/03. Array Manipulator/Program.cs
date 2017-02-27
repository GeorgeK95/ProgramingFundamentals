using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Array_Manipulator
{
    class Program
    {
        private static List<int> numbers;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            ExecuteCommands("");
            PrintResult();
        }

        private static void ExecuteCommands(string input)
        {
            input = Console.ReadLine();

            switch (input.Split(' ')[0])
            {
                case "add":
                    ExecuteAdd(input);
                    ExecuteCommands("");
                    break;
                case "addMany":
                    ExecuteAddMany(input);
                    ExecuteCommands("");
                    break;
                case "contains":
                    ExecuteContains(input);
                    ExecuteCommands("");
                    break;
                case "remove":
                    ExecuteRemove(numbers[int.Parse(input.Split(' ')[1])]);
                    ExecuteCommands("");
                    break;
                case "shift":
                    ExecuteShift(input);
                    ExecuteCommands("");
                    break;
                case "sumPairs":
                    ExecutSumPairs(input);
                    ExecuteCommands("");
                    break;                   
            }
        }

        private static void ExecuteShift(string input)
        {
            int shiftPosition = int.Parse(input.Split(' ')[1]);
            int temp = 0;
            for (int i = 0; i < shiftPosition; i++)
            {
                temp = numbers[0];
                numbers.RemoveAt(0);
                numbers.Add(temp);
            }
        }

        private static void ExecuteRemove(int numberToRemove)
        {
            numbers.Remove(numberToRemove);
        }

        private static void ExecutSumPairs(string input)
        {
            for (int i = 1; i < numbers.Count; i += 2)
            {
                numbers[i - 1] += numbers[i];
            }
            for (int i = 1; i < numbers.Count; i++)
            {
                numbers.RemoveAt(i);
            }
        }

        private static void ExecuteAddMany(string input)
        {
            List<string> splittedCommandAddMany = input.Split(' ').ToList();
            int index = int.Parse(splittedCommandAddMany[1]);
            List<int> elementsToBeAdded = new List<int>();

            for (int i = 2; i < splittedCommandAddMany.Count; i++)
            {
                elementsToBeAdded.Add(int.Parse(splittedCommandAddMany[i]));
            }

            numbers.InsertRange(index, elementsToBeAdded);
        }

        private static void ExecuteAdd(string input)
        {
            List<string> splittedCommandAdd = input.Split(' ').ToList();
            int index = int.Parse(splittedCommandAdd[1]);
            int value = int.Parse(splittedCommandAdd[2]);

            numbers.Insert(index, value);
        }



        private static void ExecuteContains(string input)
        {
            int numberToCheck = int.Parse(input.Split(' ')[1]);
            Console.WriteLine(numbers.IndexOf(numberToCheck));
        }

        private static void PrintResult()
        {
            Console.Write("[");
            Console.Write(string.Join(", ", numbers));
            Console.Write("]");
        }
    }
}
