using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Portal
{
    class Program
    {
        private static List<List<char>> list = new List<List<char>>();
        private static int turns = 1;
        private static bool foundExit = false;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();
                List<char> temp = inputLine.ToList();
                list.Add(temp);
            }

            string commandLine = Console.ReadLine();
            ExecuteCommands(commandLine);
        }

        private static void ExecuteCommands(string commandLine)
        {
            for (int i = 0; i < commandLine.Length; i++)
            {
                char current = commandLine[i];

                int row = GetStartRow();
                int col = GetStartCol();

                switch (current)
                {
                    case 'D':
                        list[row][col] = 'O';
                        GoDown(row + 1, col);
                        break;
                    case 'U':
                        list[row][col] = 'O';
                        GoUp(row - 1, col);
                        break;
                    case 'L':
                        list[row][col] = 'O';
                        GoLeft(row, col - 1);
                        break;
                    case 'R':
                        list[row][col] = 'O';
                        GoRight(row, col + 1);
                        break;
                }

                turns++;

                if (!foundExit && i == commandLine.Length - 1)
                {
                    row = GetStartRow();
                    col = GetStartCol();

                    Console.WriteLine($"Robot stuck at {row} {col}. Experiment failed.");
                }

                if (foundExit)
                {
                    break;
                }
            }


        }

        private static void GoRight(int r, int c)
        {
            if (c == list[r].Count)
            {
                GoRight(r, 0);
            }
            else
            {
                if (list[r].Count <= c)
                {
                    GoRight(r, c + 1);
                }

                else if (list[r][c] == 'O')
                {
                    list[r][c] = 'S';
                }
                else if (list[r][c] == 'E')
                {
                    Console.WriteLine($"Experiment successful. {turns} turns required.");
                    foundExit = true;
                }
            }
        }

        private static void GoLeft(int r, int c)
        {
            if (c == -1)
            {
                GoLeft(r, list[r].Count - 1);
            }
            else
            {
                if (list[r].Count <= c)
                {
                    GoLeft(r, c - 1);
                }

                else if (list[r][c] == 'O')
                {
                    list[r][c] = 'S';
                }
                else if (list[r][c] == 'E')
                {
                    Console.WriteLine($"Experiment successful. {turns} turns required.");
                    foundExit = true;
                }
            }
        }

        private static void GoUp(int r, int c)
        {
            if (r == -1)
            {
                GoUp(list.Count - 1, c);
            }
            else
            {
                if (list[r].Count <= c)
                {
                    GoUp(r - 1, c);
                }

                else if (list[r][c] == 'O')
                {
                    list[r][c] = 'S';
                }
                else if (list[r][c] == 'E')
                {
                    Console.WriteLine($"Experiment successful. {turns} turns required.");
                    foundExit = true;
                }
            }
        }

        private static void GoDown(int r, int c)
        {
            if (r == list.Count)
            {
                GoDown(0, c);
            }
            else
            {
                if (list[r].Count <= c)
                {
                    GoDown(r + 1, c);
                }

                else if (list[r][c] == 'O')
                {
                    list[r][c] = 'S';
                }
                else if (list[r][c] == 'E')
                {
                    Console.WriteLine($"Experiment successful. {turns} turns required.");
                    foundExit = true;
                }
            }

        }
        private static int GetStartCol()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    if (list[i][j] == 'S')
                    {
                        return j;
                    }
                }
            }

            return -1;
        }

        private static int GetStartRow()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    if (list[i][j] == 'S')
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
