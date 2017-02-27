using System;
using System.Collections.Generic;
using System.Linq;
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
            Dictionary<string, Dictionary<string, long>> rootName = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string pattern = @"\b(.*?)(?:(\\.*)*\\)(.*);([\d]+\b)";
                MatchCollection mc = Regex.Matches(line, pattern);

                foreach (Match item in mc)
                {
                    string root = item.Groups[1].ToString();
                    string fileName = item.Groups[3].ToString();
                    long size = long.Parse(item.Groups[4].ToString());

                    if (!rootName.ContainsKey(root))
                    {
                        var temp = new Dictionary<string, long>();
                        temp.Add(fileName, size);
                        rootName.Add(root, temp);
                    }
                    else
                    {
                        Dictionary<string, long> temp = rootName[root];
                        if (!temp.ContainsKey(fileName))
                        {
                            temp.Add(fileName, size);
                        }
                        else
                        {
                            temp[fileName] = size;
                        }

                        rootName[root] = temp;

                    }

                }

            }

            Print(rootName);
        }

        private static void Print(Dictionary<string, Dictionary<string, long>> rootName)
        {
            string query = Console.ReadLine();
            string[] splittedQuery = query.Split(' ');
            bool isPrinted = false;

            if (rootName.ContainsKey(splittedQuery[2]))
            {
                foreach (var file in rootName[splittedQuery[2]].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    if (file.Key.Contains($".{splittedQuery[0]}"))
                    {
                        isPrinted = true;
                        Console.WriteLine($"{file.Key} - {file.Value} KB");
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
