using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Georgi\\Downloads\\SU\\FDLab\\Resources\\01. Odd Lines\\Input.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                if (IsOdd(i))
                {
                    File.AppendAllText(@"C:\Users\Georgi\Downloads\SU\FDLab\Resources\01. Odd Lines\output.txt", lines[i]);
                    File.AppendAllText(@"C:\Users\Georgi\Downloads\SU\FDLab\Resources\01. Odd Lines\output.txt", Environment.NewLine);
                }
            }
        }

        private static bool IsOdd(int i)
        {
            return (i % 2 == 0) ? false : true;
        }
    }
}
