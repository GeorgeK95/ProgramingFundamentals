using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Matrix_Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> matrix = GetMatrix();
            ExecuteCommands(matrix);
            PrintResult(matrix);
        }

        private static void PrintResult(List<List<int>> matrix)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static void ExecuteCommands(List<List<int>> matrix)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command.Equals("end"))
                {
                    break;
                }

                switch (command.Split()[0])
                {
                    case "remove":
                        ExecuteRemove(matrix, command);
                        break;
                    case "insert":
                        ExecuteInsert(command, matrix);
                        break;
                    case "swap":
                        ExecuteSwap(command, matrix);
                        break;
                }
            }
        }
        private static void ExecuteRemove(List<List<int>> matrix, string command)
        {
            string type = command.Split()[1];
            string rowCol = command.Split()[2];
            int index = int.Parse(command.Split()[3]);

            if (rowCol == "row")
            {
                List<int> elements = matrix[index];
                if (type == "positive") elements.RemoveAll(x => x >= 0);
                else if (type == "negative") elements.RemoveAll(x => x < 0);
                else if (type == "odd") elements.RemoveAll(x => x % 2 != 0);
                else if (type == "even") elements.RemoveAll(x => x % 2 == 0);
                matrix[index] = elements;
            }
            else if (rowCol == "col")
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i].Count > index)
                    {
                        List<int> elements = matrix[i];
                        if (type == "positive" && elements[index] >= 0) elements.RemoveAt(index);
                        else if (type == "negative" && elements[index] < 0) elements.RemoveAt(index);
                        else if (type == "odd" && elements[index] % 2 != 0) elements.RemoveAt(index);
                        else if (type == "even" && elements[index] % 2 == 0) elements.RemoveAt(index);
                        matrix[i] = elements;
                    }
                }
            }

        }
        private static void ExecuteSwap(string command, List<List<int>> matrix)
        {
            int row1 = int.Parse(command.Split()[1]);
            int row2 = int.Parse(command.Split()[2]);

            var temp1 = matrix[row1];
            var temp2 = matrix[row2];

            matrix[row1] = temp2;
            matrix[row2] = temp1;
        }

        private static void ExecuteInsert(string command, List<List<int>> matrix)
        {
            int row = int.Parse(command.Split()[1]);
            int element = int.Parse(command.Split()[2]);

            matrix[row].Insert(0, element);
        }

        private static List<List<int>> GetMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            List<List<int>> matrix = new List<List<int>>(rows);

            for (int i = 0; i < rows; i++)
            {
                int[] splitted = Console.ReadLine().Split().Select(int.Parse).ToArray();
                List<int> temp = new List<int>();

                foreach (var element in splitted)
                {
                    temp.Add(element);
                }

                matrix.Add(temp);
            }

            return matrix;
        }
    }
}
