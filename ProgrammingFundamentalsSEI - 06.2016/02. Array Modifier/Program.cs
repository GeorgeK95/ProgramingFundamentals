using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> list = Console.ReadLine().Split().Select(long.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("end"))
                {
                    PrintResult(list);
                    break;
                }

                ExecuteCommand(command, list);
            }
        }

        private static void PrintResult(List<long> list)
        {
            Console.WriteLine(string.Join(", ", list));
        }

        private static void ExecuteCommand(string command, List<long> list)
        {
            switch (command.Split()[0])
            {
                case "swap":
                    ExecuteSwap(list, command);
                    break;
                case "multiply":
                    ExecuteMultiply(list, command);
                    break;
                case "decrease":
                    ExecuteDecrease(list, command);
                    break;
            }
        }

        private static void ExecuteDecrease(List<long> list, string command)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] -= 1;
            }
        }

        private static void ExecuteMultiply(List<long> list, string command)
        {
            string[] splitted = command.Split();
            int firstIndex = int.Parse(splitted[1]);
            int secondIndex = int.Parse(splitted[2]);

            long elementFirstIndex = list[firstIndex];
            long elementSecondIndex = list[secondIndex];

            long result = elementFirstIndex * elementSecondIndex;
            list[firstIndex] = result;
        }

        private static void ExecuteSwap(List<long> list, string command)
        {
            string[] splitted = command.Split();
            int firstIndex = int.Parse(splitted[1]);
            int secondIndex = int.Parse(splitted[2]);

            long element = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = element;
        }
    }
}
