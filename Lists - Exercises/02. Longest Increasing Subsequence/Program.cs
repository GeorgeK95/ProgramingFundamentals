using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();
            int[] lengths = new int[numbers.Length];
            int[] previous = new int[numbers.Length];
            previous[0] = -1;
            lengths[0] = 1;

            PerformAction(numbers, previous, lengths);

            Console.WriteLine(string.Join(" ", Print(lengths, previous, numbers)));
        }

        private static void PerformAction(int[] numbers, int[] previous, int[] lengths)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int current = numbers[i];
                int[] lenghtPreviousArray = GetMaxLenghtAndPreviousElementIndex(lengths, numbers[i], numbers, i);
                int length = lenghtPreviousArray[0];
                int currentPrevious = lenghtPreviousArray[1];
                lengths[i] = length;
                previous[i] = currentPrevious;
            }
        }

        private static List<int> Print(int[] lengths, int[] previous, int[] numbers)
        {
            int limit = GetBiggestLength(lengths)[0];
            int index = GetBiggestLength(lengths)[1];
            List<int> resultNumbers = new List<int>();

            for (int i = 0; i < limit; i++)
            {
                resultNumbers.Add(numbers[index]);
                index = previous[index];
            }

            resultNumbers.Reverse();
            return resultNumbers;
        }

        private static int[] GetBiggestLength(int[] l)
        {
            int biggest = 0;
            int index = 0;

            for (int i = 0; i < l.Length; i++)
            {
                if (l[i] > biggest)
                {
                    biggest = l[i];
                    index = i;
                }
            }

            int[] lengthIndexArray = new int[2];
            lengthIndexArray[0] = biggest;
            lengthIndexArray[1] = index;
            return lengthIndexArray;
        }

        private static int[] GetMaxLenghtAndPreviousElementIndex(int[] lengths, int comparator, int[] numbers, int limit)
        {
            int[] lengthPrevValuesArray = new int[2];
            int maxLength = 0;
            int maxPrevious = -1;

            for (int k = 0; k < limit; k++)
            {
                int currentLength = lengths[k];
                int currentPrev = numbers[k];

                if ((currentLength > maxLength) && (currentPrev < comparator))
                {
                    maxLength = currentLength;
                    maxPrevious = k;
                }
            }

            maxLength++;

            lengthPrevValuesArray[0] = maxLength;
            lengthPrevValuesArray[1] = maxPrevious;
            return lengthPrevValuesArray;
        }

    }
}
