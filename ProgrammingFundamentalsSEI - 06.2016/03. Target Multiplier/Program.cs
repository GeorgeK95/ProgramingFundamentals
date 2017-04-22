using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Target_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<long>> matrix = GetMatrix();
            DoTargetMultiply(matrix);
            PrintMatrix(matrix);
        }

        private static void DoTargetMultiply(List<List<long>> matrix)
        {
            string[] splittedInput = Console.ReadLine().Split();

            int targetRow = int.Parse(splittedInput[0]);
            int targetCol = int.Parse(splittedInput[1]);

            ChangeMatrixValues(matrix, targetRow, targetCol);
        }

        private static void ChangeMatrixValues(List<List<long>> matrix, int targetRow, int targetCol)
        {
            long result = GetNeighborsSum(matrix, targetCol, targetRow);

            ChangeUp(matrix, targetRow, targetCol);
            ChangeDown(matrix, targetRow, targetCol);
            ChangeLeft(matrix, targetRow, targetCol);
            ChangeRight(matrix, targetRow, targetCol);

            matrix[targetRow][targetCol] = result;
        }

        private static void ChangeRight(List<List<long>> matrix, int targetRow, int targetCol)
        {
            matrix[targetRow][targetCol + 1] *= matrix[targetRow][targetCol];
        }

        private static void ChangeLeft(List<List<long>> matrix, int targetRow, int targetCol)
        {
            matrix[targetRow][targetCol - 1] *= matrix[targetRow][targetCol];
        }

        private static void ChangeDown(List<List<long>> matrix, int targetRow, int targetCol)
        {
            int counter = 0;
            int index = targetCol - 1;

            while (counter < 3)
            {
                matrix[targetRow + 1][index] *= matrix[targetRow][targetCol];
                counter++;
                index++;
            }
        }

        private static void ChangeUp(List<List<long>> matrix, int targetRow, int targetCol)
        {
            int counter = 0;
            int index = targetCol - 1;

            while (counter < 3)
            {
                matrix[targetRow - 1][index] *= matrix[targetRow][targetCol];
                counter++;
                index++;
            }

        }

        private static long GetNeighborsSum(List<List<long>> matrix, int targetCol, int targetRow)
        {
            long up = GetUpSum(matrix, targetRow, targetCol);
            long down = GetDownSum(matrix, targetRow, targetCol);
            long left = GetLeftSum(matrix, targetRow, targetCol);
            long right = GetRightSum(matrix, targetRow, targetCol);

            long result = (up + down + left + right) * matrix[targetRow][targetCol];
            return result;
        }

        private static long GetRightSum(List<List<long>> matrix, int targetRow, int targetCol)
        {
            return matrix[targetRow][targetCol + 1];
        }

        private static long GetLeftSum(List<List<long>> matrix, int targetRow, int targetCol)
        {
            return matrix[targetRow][targetCol - 1];
        }

        private static long GetDownSum(List<List<long>> matrix, int targetRow, int targetCol)
        {
            int counter = 0;
            long sum = 0;
            int index = targetCol - 1;

            while (counter < 3)
            {
                sum += matrix[targetRow + 1][index];
                counter++;
                index++;
            }

            return sum;
        }

        private static long GetUpSum(List<List<long>> matrix, int targetRow, int targetCol)
        {
            int counter = 0;
            long sum = 0;
            int index = targetCol - 1;

            while (counter < 3)
            {
                sum += matrix[targetRow - 1][index];
                counter++;
                index++;
            }

            return sum;
        }

        private static void PrintMatrix(List<List<long>> matrix)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static List<List<long>> GetMatrix()
        {
            List<List<long>> matrix = new List<List<long>>();
            string[] splittedInput = Console.ReadLine().Split();

            int rows = int.Parse(splittedInput[0]);
            int cols = int.Parse(splittedInput[1]);

            for (int i = 0; i < rows; i++)
            {
                string[] currentRowSplitted = Console.ReadLine().Split();
                List<long> temp = new List<long>();

                for (int j = 0; j < cols; j++)
                {
                    temp.Add(long.Parse(currentRowSplitted[j]));
                }

                matrix.Add(temp);
            }

            return matrix;
        }
    }
}
