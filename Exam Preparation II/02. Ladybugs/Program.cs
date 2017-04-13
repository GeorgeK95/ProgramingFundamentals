using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] field = GetField(n);

            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("end"))
                {
                    break;
                }

                int startIndex = GetStartIndex(command);
                string dir = GetDir(command);
                int length = GetLength(command);

                if (startIndex >= 0 && startIndex < n)
                {
                    if (field[startIndex] == 1)
                    {
                        PerformFly(field, startIndex, dir, length);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", field));
        }

        private static void PerformFly(int[] field, int startIndex, string dir, int length)
        {
            if (length < 0)
            {
                if (dir.Equals("left"))
                {
                    dir = "right";
                }
                else
                {
                    dir = "left";
                }

                length = Math.Abs(length);
            }

            field[startIndex] = 0;

            if (dir.Equals("right"))
            {
                PerformFlyRecRight(field, startIndex, dir, length);
            }
            else
            {
                PerformFlyRecLeft(field, startIndex, dir, length);
            }
        }

        private static void PerformFlyRecLeft(int[] field, int startIndex, string dir, int length)
        {
            int newPos = startIndex - length;

            if (newPos < 0)
            {
                return;
            }
            if (field[newPos] == 0)
            {
                field[newPos] = 1;
                return;
            }


            PerformFlyRecLeft(field, newPos, dir, length);
        }

        private static void PerformFlyRecRight(int[] field, int startIndex, string dir, int length)
        {
            int newPos = startIndex + length;

            if (newPos >= field.Length)
            {
                return;
            }
            if (field[newPos] == 0)
            {
                field[newPos] = 1;
                return;
            }


            PerformFlyRecRight(field, newPos, dir, length);
        }

        private static int GetLength(string command)
        {
            string[] splitted = command.Split();
            return int.Parse(splitted[2]);
        }

        private static string GetDir(string command)
        {
            string[] splitted = command.Split();
            return splitted[1];
        }

        private static int GetStartIndex(string command)
        {
            string[] splitted = command.Split();
            return int.Parse(splitted[0]);
        }

        private static int[] GetField(int n)
        {
            int[] field = new int[n];
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var index in indexes)
            {
                if (index >= 0 && index < n)
                {
                    field[index] = 1;
                }
            }

            return field;
        }
    }
}
