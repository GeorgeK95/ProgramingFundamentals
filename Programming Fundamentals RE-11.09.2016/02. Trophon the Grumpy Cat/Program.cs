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
            int[] field = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int startPosition = int.Parse(Console.ReadLine());
            string itemsType = Console.ReadLine();
            string priceType = Console.ReadLine();

            if (field.Length > 2)
            {
                long leftResult = CalculateLeft(field, startPosition, itemsType, priceType);
                long rightResult = CalculateRight(field, startPosition, itemsType, priceType);

                PrintResult(leftResult, rightResult);
            }
            else
            {
                Console.WriteLine("Not enough elements to do the task.");
            }

        }

        private static void PrintResult(long leftResult, long rightResult)
        {
            if (leftResult >= rightResult)
            {
                Console.WriteLine($"Left - {leftResult}");
            }
            else
            {
                Console.WriteLine($"Right - {rightResult}");
            }
        }

        private static long CalculateRight(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            if (itemsType.Equals("expensive") && priceType.Equals("positive"))
            {
                long expensivePositiveRight = m11(field, startPosition, itemsType, priceType);
                res = expensivePositiveRight;
            }
            else if (itemsType.Equals("expensive") && priceType.Equals("negative"))
            {
                long expensiveNegativeRight = m22(field, startPosition, itemsType, priceType);
                res = expensiveNegativeRight;
            }
            else if (itemsType.Equals("expensive") && priceType.Equals("all"))
            {
                long expensiveAllRight = m33(field, startPosition, itemsType, priceType);
                res = expensiveAllRight;
            }
            else if (itemsType.Equals("cheap") && priceType.Equals("positive"))
            {
                long cheapPositiveRight = m44(field, startPosition, itemsType, priceType);
                res = cheapPositiveRight;
            }
            else if (itemsType.Equals("cheap") && priceType.Equals("negative"))
            {
                long cheapNegativeRight = m55(field, startPosition, itemsType, priceType);
                res = cheapNegativeRight;
            }
            else if (itemsType.Equals("cheap") && priceType.Equals("all"))
            {
                long cheapAllRight = m66(field, startPosition, itemsType, priceType);
                res = cheapAllRight;
            }

            return res;
        }

        private static long m66(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = startPosition + 1; i < field.Length; i++)
            {
                int currItem = field[i];

                if (currItem <= field[startPosition])
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long m55(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = startPosition + 1; i < field.Length; i++)
            {
                int currItem = field[i];

                if (currItem <= field[startPosition] && currItem <= 0)
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long m44(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = startPosition + 1; i < field.Length; i++)
            {
                int currItem = field[i];

                if (currItem <= field[startPosition] && currItem >= 0)
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long m33(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = startPosition + 1; i < field.Length; i++)
            {
                int currItem = field[i];

                if (currItem >= field[startPosition])
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long m22(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = startPosition + 1; i < field.Length; i++)
            {
                int currItem = field[i];

                if (currItem >= field[startPosition] && currItem <= 0)
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long m11(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = startPosition + 1; i < field.Length; i++)
            {
                int currItem = field[i];

                if (currItem >= field[startPosition] && currItem >= 0)
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long CalculateLeft(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            if (itemsType.Equals("expensive") && priceType.Equals("positive"))
            {
                long expensivePositiveLeft = m1(field, startPosition, itemsType, priceType);
                res = expensivePositiveLeft;
            }
            else if (itemsType.Equals("expensive") && priceType.Equals("negative"))
            {
                long expensiveNegativeLeft = m2(field, startPosition, itemsType, priceType);
                res = expensiveNegativeLeft;
            }
            else if (itemsType.Equals("expensive") && priceType.Equals("all"))
            {
                long expensiveAllLeft = m3(field, startPosition, itemsType, priceType);
                res = expensiveAllLeft;
            }
            else if (itemsType.Equals("cheap") && priceType.Equals("positive"))
            {
                long cheapPositiveLeft = m4(field, startPosition, itemsType, priceType);
                res = cheapPositiveLeft;
            }
            else if (itemsType.Equals("cheap") && priceType.Equals("negative"))
            {
                long cheapNegativeLeft = m5(field, startPosition, itemsType, priceType);
                res = cheapNegativeLeft;
            }
            else if (itemsType.Equals("cheap") && priceType.Equals("all"))
            {
                long cheapAllLeft = m6(field, startPosition, itemsType, priceType);
                res = cheapAllLeft;
            }

            return res;
        }

        private static long m6(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = 0; i < startPosition; i++)
            {
                int currItem = field[i];

                if (currItem < field[startPosition])
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long m5(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = 0; i < startPosition; i++)
            {
                int currItem = field[i];

                if (currItem < field[startPosition] && currItem <= 0)
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long m4(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = 0; i < startPosition; i++)
            {
                int currItem = field[i];

                if (currItem < field[startPosition] && currItem >= 0)
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long m3(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = 0; i < startPosition; i++)
            {
                int currItem = field[i];

                if (currItem >= field[startPosition])
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long m2(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = 0; i < startPosition; i++)
            {
                int currItem = field[i];

                if (currItem >= field[startPosition] && currItem <= 0)
                {
                    res += field[i];
                }

            }

            return res;
        }

        private static long m1(int[] field, int startPosition, string itemsType, string priceType)
        {
            long res = 0;

            for (int i = 0; i < startPosition; i++)
            {
                int currItem = field[i];

                if (currItem >= field[startPosition] && currItem >= 0)
                {
                    res += field[i];
                }

            }

            return res;
        }

    }
}
