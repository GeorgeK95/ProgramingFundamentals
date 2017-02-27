using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Georgi\\Downloads\\SU\\FDLab\\Resources\\02. Line numbers\\Input.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string currLine = lines[i];
                currLine = EditCurrLine(currLine, i + 1);
                File.AppendAllText(@"C:\Users\Georgi\Downloads\SU\FDLab\Resources\02. Line Numbers\output.txt", currLine + Environment.NewLine);
            }
        }

        private static string EditCurrLine(string currLine, int num)
        {
            return currLine.Insert(0, num.ToString() + ". "); 
        }
    }
}
