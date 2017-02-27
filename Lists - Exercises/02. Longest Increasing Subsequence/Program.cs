using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists___Exercises
{

    class Program
    {
        private static int[] numbers;
        private static int[] lenght;
        private static int[] previous;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            lenght = new int[numbers.Length];
            previous = new int[numbers.Length];

            lenght[0] = 1;
            previous[0] = -1;

            for (int i = 1; i < numbers.Length; i++)
            {
                FillLenghtAndPrevious(i);
            }

            PrintLongestIncreasingSubSequence();

        }

        private static void PrintLongestIncreasingSubSequence()
        {
            List<int> printList = new List<int>();

            int lenghtMaxIndex = GetLenghtMaxIndex();
            int i = lenghtMaxIndex;

            while(i != -1)
            {
                int element = numbers[i];
                printList.Add(element);

                if (previous[i] == -1)
                {
                    break;
                }
                
                i = previous[i];
            }

            PrintResult(printList);
        }

        private static void PrintResult(List<int> printList)
        {
            printList.Reverse();

            for (int i = 0; i < printList.Count; i++)
            {
                Console.Write(printList[i] + " ");
            }
        }

        private static int GetLenghtMaxIndex()
        {
            int index = 0;
            int maxValue = int.MinValue;

            for (int i = 0; i < lenght.Length; i++)
            {
                if (lenght[i] > maxValue)
                {
                    maxValue = lenght[i];
                    index = i;
                }
            }

            return index;
        }

        private static void FillLenghtAndPrevious(int i)
        {
            int valueOfMaxLenghtElement = int.MinValue;

            for (int index = 0; index < i; index++)
            {
                if (lenght[index] > valueOfMaxLenghtElement && (numbers[i] > numbers[index]))
                {
                    valueOfMaxLenghtElement = lenght[index];
                    previous[i] = index;
                }
            }

            if (valueOfMaxLenghtElement == int.MinValue)
            {
                lenght[i] = 1;
                previous[i] = -1;
            }
            else
            {
                lenght[i] = valueOfMaxLenghtElement + 1;        
            }
        }
    }
}
