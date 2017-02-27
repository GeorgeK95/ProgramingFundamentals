using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Ladybugs
{
    class Program
    {
        static int[] field;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); field = new int[n];
            FillLadiesIndexexInTheField();
            string command = Console.ReadLine();

            while (!command.Equals("end"))
            {
                string[] splittedCommand = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int startIndex = int.Parse(splittedCommand[0]);
                string direction = splittedCommand[1];
                int count = int.Parse(splittedCommand[2]);

                if (count < 0)
                {
                    if (direction.Equals("right"))
                    {
                        direction = "left";
                    }
                    else if (direction.Equals("left"))
                    {
                        direction = "right";
                    }

                    count = Math.Abs(count);
                }

                Fly(startIndex, direction, count, false);
                //  Fly(startIndex, direction, count);

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }

        private static void FillLadiesIndexexInTheField()
        {
            string ladiesIndexes = Console.ReadLine();
            ladiesIndexes = Regex.Replace(ladiesIndexes, @"\s+", " ");
            int[] b = ladiesIndexes.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            FillCells(b);
        }

        private static void Fly(int startIndex, string direction, int count, bool isFlying)
        {
            if (direction.Equals("right"))
            {
                FlyRight(startIndex, count, false);
            }
            else
            {
                FlyLeft(startIndex, count, false);
            }
            /*if (startIndex >= 0 && startIndex < field.Length && Math.Abs(count) < field.Length)
            {
                if (field[startIndex] == 1)
                {
                    if (!isFlying)
                    {
                        field[startIndex] = 0;
                    }
                    if (direction.Equals("right"))
                    {
                        if (startIndex + count < field.Length)
                        {
                            if (field[startIndex + count] == 1)
                            {
                                Fly(startIndex + count, direction, count, true);
                            }
                            else
                            {
                                field[startIndex + count] = 1;
                            }
                        }
                    }
                    else
                    {
                        if (startIndex - Math.Abs(count) >= 0)
                        {
                            if (field[startIndex - count] == 1)
                            {
                                Fly(startIndex - count, direction, count, true);
                            }
                            else
                            {
                                field[startIndex - count] = 1;
                            }
                        }

                    }
                }

            }*/
        }

        private static void FlyLeft(int startIndex, int count, bool isFlying)
        {
            if (startIndex >= 0 && startIndex < field.Length && field[startIndex] == 1)
            {
                if (!isFlying)
                {
                    field[startIndex] = 0;
                }
                if (startIndex - Math.Abs(count) >= 0)
                {
                    if (field[startIndex - count] == 1)
                    {
                        FlyLeft(startIndex - count, count, true);
                    }
                    else
                    {
                        field[startIndex - count] = 1;
                    }
                }
            }
        }

        private static void FlyRight(int startIndex, int count, bool isFlying)
        {
            if (startIndex >= 0 && startIndex < field.Length && field[startIndex] == 1)
            {
                if (!isFlying)
                {
                    field[startIndex] = 0;
                }
                if (startIndex + count < field.Length)
                {
                    if (field[startIndex + count] == 1)
                    {
                        FlyRight(startIndex + count, count, true);
                    }
                    else
                    {
                        field[startIndex + count] = 1;
                    }
                }
            }
        }

        private static void FillCells(int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                int index = b[i];
                if (index >= 0 && index < field.Length)
                {
                    field[index] = 1;
                }
            }
        }
    }
}
