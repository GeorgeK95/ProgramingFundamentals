using System;

namespace _04.Trifon_s_Quest
{

    public class TrifonQuest
    {
        private static long health;
        private static long turns = 0;
        private static bool isAlive = true;

        static void Main(string[] args)
        {
            health = int.Parse(Console.ReadLine());
            String[] sizes = Console.ReadLine().Split(' ');
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);
            char[,] matrix = ReadMatrix(rows, cols);

            Quest(matrix, rows, cols);

            if (isAlive)
            {
                Console.WriteLine("Quest completed!\n" +
                        $"Health: {health}\n" +
                        $"Turns: {turns}\n");
            }
        }

        private static void Quest(char[,] matrix, int rows, int cols)
        {

            for (int i = 0; i < cols; i++)
            {

                if (i % 2 == 0)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        char current = matrix[j, i];
                        DoCommand(current, matrix, i, j);

                        if (!isAlive)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = rows - 1; j >= 0; j--)
                    {
                        char current = matrix[j, i];
                        DoCommand(current, matrix, i, j);

                        if (!isAlive)
                        {
                            break;
                        }
                    }
                }
                if (!isAlive)
                {
                    break;
                }
            }

        }

        private static void DoCommand(char current, char[,] matrix, int i, int j)
        {
            if (current == 'F')
            {
                ExecuteFight();

                if (health <= 0)
                {
                    Console.WriteLine("Died at: " + "[" + j + ", " + i + "]");
                    isAlive = false;
                }

                turns++;
            }
            else if (current == 'T')
            {
                ExecuteTrap();
                turns++;
            }
            else if (current == 'H')
            {
                ExecuteHealth();
                turns++;
            }
            else
            {
                //Empty
                turns++;
            }

        }

        private static void ExecuteHealth()
        {
            long toAdd = turns / 3;
            health += toAdd;
        }

        private static void ExecuteTrap()
        {
            turns += 2;
        }

        private static void ExecuteFight()
        {
            long toLose = turns / 2;
            health -= toLose;
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                String line = Console.ReadLine();

                for (int j = 0; j < line.Length; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            return matrix;
        }
    }

}
