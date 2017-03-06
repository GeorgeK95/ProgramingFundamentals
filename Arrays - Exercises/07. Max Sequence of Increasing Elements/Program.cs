using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            int[] array = line1.Split(' ').Select(int.Parse).ToArray();

            List<int> values = GetLongestSequenceOfIncreasingElements(array);
            Console.WriteLine(string.Join(" ", values));
        }

        private static List<int> GetLongestSequenceOfIncreasingElements(int[] array)
        {
            List<int> values = new List<int>();
            int bestLength = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                int currLength = 0;
                List<int> tempList = new List<int>();
                tempList.Add(array[i]);

                for (int j = i; j < array.Length - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        currLength++;
                        tempList.Add(array[j + 1]);

                        if (currLength > bestLength)
                        {
                            bestLength = currLength;
                            values = tempList;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return values;
        }
    }
}
