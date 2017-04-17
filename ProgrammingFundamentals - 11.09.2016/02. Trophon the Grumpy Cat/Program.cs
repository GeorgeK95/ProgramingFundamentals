using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Trophon_the_Grumpy_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startIndex = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string rating = Console.ReadLine();

            long left = CalculateLeft(arr, startIndex, type, rating);
            long right = CalculateRight(arr, startIndex, type, rating);

            Print(left, right);
        }

        private static long CalculateRight(int[] arr, int startIndex, string type, string rating)
        {
            int[] subArr = arr.Skip(startIndex + 1).Take(arr.Length - startIndex - 1).ToArray();
            long result = 0;

            switch (type)
            {
                case "cheap":
                    if (rating.Equals("positive"))
                    {
                        result = CalculateRightCheapPositive(subArr, arr[startIndex]);
                    }
                    else if (rating.Equals("negative"))
                    {
                        result = CalculateRightCheapNegative(subArr, arr[startIndex]);
                    }
                    else
                    {
                        result = CalculateRightCheapAll(subArr, arr[startIndex]);
                    }
                    break;
                case "expensive":
                    if (rating.Equals("positive"))
                    {
                        result = CalculateRightExpensivePositive(subArr, arr[startIndex]);
                    }
                    else if (rating.Equals("negative"))
                    {
                        result = CalculateRightExpensiveNegative(subArr, arr[startIndex]);
                    }
                    else
                    {
                        result = CalculateRightExpensiveAll(subArr, arr[startIndex]);
                    }
                    break;
            }

            return result;
        }

        private static long CalculateRightExpensiveAll(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number >= v)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateRightExpensiveNegative(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number >= v && number < 0)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateRightExpensivePositive(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number >= v && number >= 0)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateRightCheapAll(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number < v)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateRightCheapNegative(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number < v && number < 0)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateRightCheapPositive(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number < v && number >= 0)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateLeft(int[] arr, int startIndex, string type, string rating)
        {
            int[] subArr = arr.Take(startIndex).ToArray();
            long result = 0;

            switch (type)
            {
                case "cheap":
                    if (rating.Equals("positive"))
                    {
                        result = CalculateLeftCheapPositive(subArr, arr[startIndex]);
                    }
                    else if (rating.Equals("negative"))
                    {
                        result = CalculateLeftCheapNegative(subArr, arr[startIndex]);
                    }
                    else
                    {
                        result = CalculateLeftCheapAll(subArr, arr[startIndex]);
                    }
                    break;
                case "expensive":
                    if (rating.Equals("positive"))
                    {
                        result = CalculateLeftExpensivePositive(subArr, arr[startIndex]);
                    }
                    else if (rating.Equals("negative"))
                    {
                        result = CalculateLeftExpensiveNegative(subArr, arr[startIndex]);
                    }
                    else
                    {
                        result = CalculateLeftExpensiveAll(subArr, arr[startIndex]);
                    }
                    break;
            }

            return result;
        }

        private static long CalculateLeftExpensiveAll(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number >= v)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateLeftExpensiveNegative(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number >= v && number < 0)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateLeftExpensivePositive(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number >= v && number >= 0)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateLeftCheapAll(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number < v)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateLeftCheapNegative(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number < v && number < 0)
                {
                    result += number;
                }
            }

            return result;
        }

        private static long CalculateLeftCheapPositive(int[] subArr, int v)
        {
            long result = 0;

            foreach (var number in subArr)
            {
                if (number < v && number >= 0)
                {
                    result += number;
                }
            }

            return result;
        }

        private static void Print(long left, long right)
        {
            if (right > left)
            {
                Console.WriteLine($"Right - {right}");
            }
            else
            {
                Console.WriteLine($"Left - {left}");
            }
        }
    }
}
