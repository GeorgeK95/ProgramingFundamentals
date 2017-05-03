using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Wormhole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] maze = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = CountTurns(maze);
            Console.WriteLine(counter);
        }

        private static int CountTurns(int[] maze)
        {
            int counter = 0;

            for (int i = 0; i < maze.Length; i++)
            {
                counter++;

                if (maze[i] != 0)
                {
                    int value = maze[i];
                    maze[i] = 0;
                    i = value;
                }
            }

            return counter;
        }
    }
}
