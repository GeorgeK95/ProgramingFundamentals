using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Files
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, long>> rootNameSizeValues = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string pattern = @"\b(.*?)(?:(\\.*)*\\)(.*);([\d]+\b)";
                MatchCollection matches = Regex.Matches(line, pattern);

                foreach (Match currentMatch in matches)
                {
                    string root = currentMatch.Groups[1].ToString();
                    string name = currentMatch.Groups[3].ToString();
                    long size = long.Parse(currentMatch.Groups[4].ToString());

                    if (!rootNameSizeValues.ContainsKey(root))
                    {
                        Dictionary<string, long> temp = new Dictionary<string, long>();
                        temp.Add(name, size);
                        rootNameSizeValues.Add(root, temp);
                    }
                    else
                    {
                        Dictionary<string, long> temp = rootNameSizeValues[root];

                        if (temp.ContainsKey(name))
                        {
                            temp[name] = size;
                        }
                        else
                        {
                            temp.Add(name, size);
                        }

                        rootNameSizeValues[root] = temp;
                    }
                }

            }

            PrintDict(rootNameSizeValues);
        }

        private static void PrintDict(Dictionary<string, Dictionary<string, long>> rootNameSizeValues)
        {
            string[] query1 = Console.ReadLine().Split(' ');
            bool isPrinted = false;

            if (rootNameSizeValues.ContainsKey(query1[2]))
            {
                foreach (var file in rootNameSizeValues[query1[2]].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    if (file.Key.Contains($".{query1[0]}"))
                    {
                        Console.WriteLine($"{file.Key} - {file.Value} KB");
                        isPrinted = true;
                    }

                }
            }

            if (!isPrinted)
            {
                Console.WriteLine("No");
            }
        }
    }
}
