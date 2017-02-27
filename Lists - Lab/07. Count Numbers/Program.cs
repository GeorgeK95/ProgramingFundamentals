using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Count_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            CountNumbers(inputList);
        }

        private static void CountNumbers(List<int> inputList)
        {
            SortedDictionary<int, int> sortedDict = new SortedDictionary<int, int>();

            for (int i = 0; i < inputList.Count; i++)
            {
                if (!sortedDict.ContainsKey(inputList[i]))
                {
                    sortedDict.Add(inputList[i], 1);
                }
                else
                {
                    int value = sortedDict[inputList[i]];
                    sortedDict.Remove(inputList[i]);
                    sortedDict.Add(inputList[i], value + 1);
                }
            }

            PrintElements(sortedDict);

        }

        private static void PrintElements(SortedDictionary<int, int> sortedDict)
        {
            foreach (KeyValuePair<int, int> pair in sortedDict)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
