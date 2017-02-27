using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Array_Manipulator
{
    class Program
    {
        static int[] arr;

        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string line = Console.ReadLine();
            
            while (!line.Equals("end"))
            {
                string[] spl = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (spl.Length == 2)
                {
                    string p_1 = spl[0];

                    if (p_1.Equals("exchange"))
                    {
                        ExecuteExchangeCommand(spl);
                    }
                    else if (p_1.Equals("max"))
                    {
                        ExecuteMaxCommand(spl);
                    }
                    else if (p_1.Equals("min"))
                    {
                        ExecuteMinCommand(spl);
                    }

                }
                else if (spl.Length == 3)
                {
                    string[] spl1 = line.Split(' ');

                    if (spl1[0].Equals("first"))
                    {
                        ExecuteFirstCommand(spl1);
                    }
                    else if (spl1[0].Equals("last"))
                    {
                        ExecuteLastCommand(spl1);
                    }
                   
                }

                line = Console.ReadLine();
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.Write("[");
            Console.Write(string.Join(", ", arr));
            Console.Write("]");
        }

        private static void ExecuteLastCommand(string[] spl1)
        {
            if (int.Parse(spl1[1]) > arr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                int count = int.Parse(spl1[1]);
                List<int> container = new List<int>();

                if (count == 0)
                {
                    Print(container,false);
                }
                else
                {

                    if (spl1[2].Equals("odd"))
                    {
                        for (int i = arr.Length - 1; i >= 0; i--)
                        {
                            if (arr[i] % 2 != 0)
                            {
                                container.Add(arr[i]);
                            }
                            if (container.Count == count)
                            {
                                break;
                            }
                        }
                    }
                    else if (spl1[2].Equals("even"))
                    {
                        for (int i = arr.Length - 1; i >= 0; i--)
                        {
                            if (arr[i] % 2 == 0)
                            {
                                container.Add(arr[i]);
                            }
                            if (container.Count == count)
                            {
                                break;
                            }
                        }
                    }
                

                    Print(container,true);
                }


            }

        }

        private static void ExecuteFirstCommand(string[] spl1)
        {
            if (int.Parse(spl1[1]) > arr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                int count = int.Parse(spl1[1]);
                //int index = int.Parse(spl1[2]);
                List<int> container = new List<int>();

                if (spl1[2].Equals("odd"))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] % 2 != 0)
                        {
                            container.Add(arr[i]);
                        }
                        if (container.Count == count)
                        {
                            break;
                        }
                    }
                }
                else if (spl1[2].Equals("even"))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] % 2 == 0)
                        {
                            container.Add(arr[i]);
                        }
                        if (container.Count == count)
                        {
                            break;
                        }
                    }
                }

                Print(container, false);
            }
        }

        private static void Print(List<int> container, bool needToReverse)
        {
            if (needToReverse)
            {
                container.Reverse();
            }

            Console.Write("[");
            Console.Write(string.Join(", ", container));
            Console.WriteLine("]");
        }

        private static void ExecuteMinCommand(string[] spl)
        {
            int bestIndex = int.MaxValue;
            int maxValue = int.MaxValue;

            if (spl[1].Equals("odd"))
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 1)//ne4etno
                    {
                        if (arr[i] <= maxValue)
                        {
                            maxValue = arr[i];
                            bestIndex = i;
                        }
                    }
                }
            }
            else if (spl[1].Equals("even"))
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)//4etno
                    {
                        if (arr[i] <= maxValue)
                        {
                            maxValue = arr[i];
                            bestIndex = i;
                        }
                    }
                }

            }

            if (bestIndex == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(bestIndex);
            }
        }

        private static void ExecuteMaxCommand(string[] spl)
        {
            int bestIndex = int.MinValue;
            int maxValue = int.MinValue;

            if (spl[1].Equals("odd"))
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 1)//ne4etno
                    {
                        if (arr[i] >= maxValue)
                        {
                            maxValue = arr[i];
                            bestIndex = i;
                        }
                    }
                }
            }
            else if (spl[1].Equals("even"))
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)//4etno
                    {
                        if (arr[i] >= maxValue)
                        {
                            maxValue = arr[i];
                            bestIndex = i;
                        }
                    }
                }

            }

            if (bestIndex == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(bestIndex);
            }

        }

        private static void ExecuteExchangeCommand(string[] spl)
        {
            int index = int.Parse(spl[1]);

            if (index >= 0 && index < arr.Length)
            {
                int[] p1 = new int[index + 1];

                for (int i = 0; i < index + 1; i++)
                {
                    p1[i] = arr[i];
                }

                int[] p2 = new int[arr.Length - index - 1];
                int tempIndex = 0;

                for (int i = index + 1; i < arr.Length; i++)
                {
                    p2[tempIndex] = arr[i];
                    tempIndex++;
                }

                int[] copyP = new int[arr.Length];
                int ppp = 0;
                for (int i = 0; i < p2.Length; i++)
                {
                    copyP[i] = p2[i];
                    ppp = i;
                    ppp++;
                }
                
                for (int i = 0; i < p1.Length; i++)
                {
                    copyP[ppp] = p1[i];
                    ppp++;
                }

                arr = copyP;
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }
    }
}
