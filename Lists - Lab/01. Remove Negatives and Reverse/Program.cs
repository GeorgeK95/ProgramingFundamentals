using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();
            List<int> numbers = values.Split(' ').Select(int.Parse).ToList();

            numbers = RemoveNegativeNumbersFromList(numbers);

            numbers.Reverse();

            PrintList(numbers);
            
        }

        private static void PrintList(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
            
        }

        private static List<int> RemoveNegativeNumbersFromList(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            return numbers;
        }
    }
}
