using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Array_Manipulator
{
    class test
    {

        static List<long> values = new List<long>();

        /*static void Main()
        {
            values = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            ExecuteInstructions();
        }*/

        private static void ExecuteInstructions()
        {
            string input = Console.ReadLine();
            string[] splitted = input.Split(' ');
            string instruction = splitted[0];

            switch (instruction)
            {
                case "add":
                    int index = int.Parse(splitted[1]);
                    int value = int.Parse(splitted[2]);
                    values.Insert(index, value);

                    ExecuteInstructions();
                    break;
                case "contains":
                    int numberToCheck = int.Parse(splitted[1]);

                    if (values.Contains(numberToCheck))
                    {
                        Console.WriteLine(values.IndexOf(numberToCheck));
                    }
                    else
                    {
                        Console.WriteLine(-1);
                    }

                    ExecuteInstructions();
                    break;
                case "remove":
                    int numberToRemove = int.Parse(splitted[1]);

                    if (values.Contains(numberToRemove))
                    {
                        values.Remove(numberToRemove);
                    }

                    ExecuteInstructions();
                    break;
                case "sumPairs":
                    List<long> summedPairsList = new List<long>();
                    int summedPairsListIndex = 0;

                    for (int i = 0; i < values.Count - 1; i += 2)
                    {
                        summedPairsList.Add((values[i] + values[i + 1]));
                        summedPairsListIndex += 1;
                    }
                    values = summedPairsList;

                    ExecuteInstructions();
                    break;
                case "shift":
                    string[] splittedCommandShift = input.Split(' ').ToArray();
                    int shiftPosition = int.Parse(splittedCommandShift[1]);
                    List<long> shiftedNumbers = new List<long>();

                    for (int i = 0; i < shiftPosition; i++)
                    {
                        shiftedNumbers.Add(values[i]);

                    }
                    for (int i = 0; i < shiftPosition; i++)
                    {
                        int numberToRemove1 = int.Parse(splitted[1]);

                        if (values.Contains(numberToRemove1))
                        {
                            values.Remove(numberToRemove1);
                        }

                    }

                    values.AddRange(shiftedNumbers);

                    ExecuteInstructions();
                    break;
                case "print":
                    PrintValues();
                    break;
                case "addMany":
                    string[] splittedCommandAddMany = input.Split(' ').ToArray();
                    int valuesInt = int.Parse(splittedCommandAddMany[1]);
                    List<long> elementsToBeAdded = new List<long>();

                    for (int i = 2; i < splittedCommandAddMany.Length; i++)
                    {
                        elementsToBeAdded.Add(int.Parse(splittedCommandAddMany[i]));
                    }

                    values.InsertRange(valuesInt, elementsToBeAdded);

                    ExecuteInstructions();
                    break;
            }
        }

        private static void PrintValues()
        {
            Console.Write("[");
            for (int i = 0; i < values.Count; i++)
            {
                if (i == values.Count - 1)
                {
                    Console.Write(values[i]);
                }
                else
                {
                    Console.Write(values[i] + ", ");
                }
            }
            Console.WriteLine("]");
        }
    }
}
