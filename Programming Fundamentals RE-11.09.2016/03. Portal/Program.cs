using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Portal
{
    class Program
    {
        static char[,] m;
        static int count;

        static void Main(string[] args)
        {
            int n =  int.Parse(Console.ReadLine());
            m = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] chArr = Console.ReadLine().ToCharArray();
                FillMatrix(chArr, i);
            }

            ExecuteDirections();
           // PrintMatrixTest();
        }

        private static void FillMatrix(char[] chArr, int row)
        {
            for (int i = 0; i < chArr.Length; i++)
            {
                m[row, i] = chArr[i];
            }
            for (int i = 0; i < m.GetLength(0); i++)
            {
                if (m[row,i] == '\0' || m[row, i] == ' ')
                {
                    m[row, i] = 'n';
                }
            }
        }

        private static void ExecuteDirections()
        {
            int[] exitCoordinates = GetEndPosition();

            char[] directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                char currDir = directions[i];
                ExecureCurrentDirection(currDir);
            }

            int[] startPos = GetStartPosition();

            PrintResult(startPos, exitCoordinates);
        }

        private static void PrintResult(int[] startPos, int[] exitCoordinates)
        {
            if (startPos[0] == startPos[1] && exitCoordinates[0] == exitCoordinates[1])
            {
                Console.WriteLine($"Experiment successful. {count} turns required.");
            }
            else
            {
                Console.WriteLine($"Robot stuck at {startPos[0]} {startPos[1]}. Experiment failed.");
            }
        }

        private static int[] GetEndPosition()
        {
            int[] exitCoordinates = new int[2];

            for (int row = 0; row < m.GetLength(0); row++)
            {
                for (int col = 0; col < m.GetLength(0); col++)
                {
                    if (m[row,col] == 'E')
                    {
                        exitCoordinates[0] = row;
                        exitCoordinates[1] = col;
                    }
                }
            }

            return exitCoordinates;
        }

        private static void ExecureCurrentDirection(char currDir)
        {
            int[] startPos = GetStartPosition();
            int startRow = startPos[0];
            int startCol = startPos[1];
            m[startRow, startCol] = 'O';

            switch (currDir)
            {
                case 'U':
                    Up(startRow - 1, startCol);
                    break;
                case 'D':
                    Down(startRow + 1, startCol);
                    break;
                case 'L':
                    Left(startRow, startCol - 1);
                    break;
                case 'R':
                    Right(startRow, startCol + 1);
                    break;
                default:
                    break;
            }
        }

        private static void Right(int a, int b)
        {
            count++;
            if (b <= m.GetLength(0) - 1)
            {
                if (m[a, b] != 'n')
                {
                    m[a, b] = 'S';
                }
                else
                {
                    Right(a, b + 1);
                }
            }

            else
            {
                if (b > m.GetLength(0))
                {
                    b = -1;
                }
                Right(a, b + 1);
            }
        }

        private static void Left(int a, int b)
        {
            count++;
            if (b >= 0)
            {
                if (m[a, b] != 'n')
                {
                    m[a, b] = 'S';
                }
                else
                {
                    Left(a, b - 1);
                }
            }

            else
            {
                if (b < 0)
                {
                    b = m.GetLength(0);
                }
                Left(a, b - 1);
            }
        }

        private static void Down(int a, int b)
        {
            count++;
            if (a <= m.GetLength(0) - 1)
            {
                if (m[a, b] != 'n')
                {
                    m[a, b] = 'S';
                }
                else
                {
                    Down(a + 1, b);
                }
            }

            else
            {
                if (a > m.GetLength(0))
                {
                    a = -1;
                }
                Down(a + 1, b);
            }
        }

        private static void Up(int a, int b)
        {
            count++;
            if (a >= 0)
            {
                if (m[a, b] != 'n')
                {
                    m[a, b] = 'S';
                }
                else
                {
                    Up(a - 1, b);
                }
            }
            
            else
            {
                if (a < 0)
                {
                    a = m.GetLength(0);
                }
                Up(a - 1, b);
            }
        }

        private static int[] GetStartPosition()
        {
            int[] rowCol = new int[2];

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] == 'S')
                    {
                        rowCol[0] = i;
                        rowCol[1] = j;
                    }
                }
            }

            return rowCol;
        }

        private static void PrintMatrixTest()
        {
            int rowLength = m.GetLength(0);
            int colLength = m.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", m[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }

        private static void FillEmptyPlacesInMatrix()
        {
            for (int row = 0; row < m.GetLength(0); row++)
            {
                for (int col = 0; col < m.GetLength(1); col++)
                {
                    if (m[row, col] == '\0')
                    {
                        m[row, col] = 'n';//none
                    }
                }
            }
        }
    }
}
