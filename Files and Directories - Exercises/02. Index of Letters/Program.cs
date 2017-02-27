using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.Index_of_Letters
{
    class Program
    {
        static string INPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex2\\input.txt";
        static string OUTPUT_PATH = "C:\\Users\\Georgi\\Downloads\\SU\\FDEExercises\\ex2\\output.txt";

        static void Main(string[] args)
        {
            string word = File.ReadAllText(INPUT_PATH);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                char currLetter = word[i];
                sb.Append(($"{currLetter} -> {(int)currLetter - (int)'a'}"));
                sb.Append(Environment.NewLine);
            }

            File.WriteAllText(OUTPUT_PATH, sb.ToString());
        }
    }
}
