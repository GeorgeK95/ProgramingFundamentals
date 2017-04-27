using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.Critical_Breakpoint
{
    class Line
    {
        public long X1 { get; set; }
        public long Y1 { get; set; }
        public long X2 { get; set; }
        public long Y2 { get; set; }
        public long CriticalRatio { get; set; }

        public Line(long a, long b, long c, long d, long cr)
        {
            this.X1 = a;
            this.Y1 = b;
            this.X2 = c;
            this.Y2 = d;
            this.CriticalRatio = cr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Line> lines = new List<Line>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("Break it."))
                {
                    break;
                }

                long[] inputNumbers = input.Split().Select(long.Parse).ToArray();
                long criticalRatio = GetCR(inputNumbers);

                Line line = new Line(inputNumbers[0], inputNumbers[1], inputNumbers[2], inputNumbers[3], criticalRatio);
                lines.Add(line);
            }

            PrintResult(lines);
        }

        private static void PrintResult(List<Line> lines)
        {
            BigInteger currentCriticalRatio = 0;
            bool exist = true;

            foreach (Line currentLine in lines)
            {
                if (currentCriticalRatio == 0 && currentLine.CriticalRatio != 0)
                {
                    currentCriticalRatio = currentLine.CriticalRatio;
                }

                if (currentLine.CriticalRatio != currentCriticalRatio && currentLine.CriticalRatio != 0)
                {
                    exist = false;
                    break;
                }
            }

            if (exist)
            {
                foreach (var line in lines)
                {
                    Console.WriteLine($"Line: [{line.X1}, {line.Y1}, {line.X2}, {line.Y2}]");
                }

                BigInteger remainder = 0;
                BigInteger.DivRem(BigInteger.Pow(currentCriticalRatio, lines.Count), lines.Count, out remainder);
                Console.WriteLine($"Critical Breakpoint: {remainder}");
            }
            else
            {
                Console.WriteLine("Critical breakpoint does not exist.");
            }
        }

        private static long GetCR(long[] nums)
        {
            return Math.Abs((nums[3] + nums[2]) - (nums[1] + nums[0]));
        }
    }
}
