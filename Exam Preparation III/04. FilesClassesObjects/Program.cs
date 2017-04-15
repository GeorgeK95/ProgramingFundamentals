using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.FilesClassesObjects
{
    class File
    {
        public string name { get; set; }
        public string size { get; set; }

        public File(string name, string size)
        {
            this.name = name;
            this.size = size;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<File>> files = new Dictionary<string, List<File>>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string root = GetRoot(line);
                string filename = GetFileName(line);
                string size = GetSize(line);

                AddFileToFiles(files, root, filename, size);
            }

            string extension = Console.ReadLine();
            Print(files, extension);
        }

        private static string GetSize(string line)
        {
            StringBuilder size = new StringBuilder();

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (line[i] == ';')
                {
                    break;
                }
                else
                {
                    size.Append(line[i]);
                }
            }

            string sizeStr = Reverse(size.ToString());
            sizeStr = sizeStr.Trim();
            return sizeStr;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private static string GetFileName(string line)
        {
            StringBuilder fileName = new StringBuilder();
            bool toWrite = false;

            for (int i = line.Length - 1; i >= 0; i--)
            {

                if (line[i] == '\\')
                {
                    break;
                }
                if (toWrite)
                {
                    fileName.Append(line[i]);
                }
                if (line[i] == ';')
                {
                    toWrite = true;
                }

            }

            string name = Reverse(fileName.ToString());
            name = name.Trim();
            return name;
        }

        private static string GetRoot(string line)
        {
            StringBuilder root = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != '\\')
                {
                    root.Append(line[i]);
                }
                else
                {
                    break;
                }
            }

            return root.ToString();
        }

        private static void Print(Dictionary<string, List<File>> files, string extension)
        {
            string ext = extension.Split()[0];
            string root = extension.Split()[2];

            if (files.ContainsKey(root))
            {
                List<File> toPrint = files[root];
                bool isPrinted = false;

                foreach (var file in toPrint.OrderByDescending(x => x.size).ThenBy(x => x.name))
                {
                    if (GetExtension(file).Equals(ext))
                    {
                        Console.WriteLine($"{file.name} - {file.size} KB");
                        isPrinted = true;
                    }
                }

                if (!isPrinted)
                {
                    Console.WriteLine("No");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static String GetExtension(File file)
        {
            string name = file.name;
            StringBuilder extension = new StringBuilder();

            for (int i = name.Length - 1; i >= 0; i--)
            {
                if (name[i] == '.')
                {
                    break;
                }
                else
                {
                    extension.Append(name[i]);
                }
            }

            string res = Reverse(extension.ToString());
            return res;
        }

        private static void AddFileToFiles(Dictionary<string, List<File>> files, string root, string filename, string size)
        {
            if (!files.ContainsKey(root))
            {
                var newFileList = new List<File>();
                File newFile = new File(filename, size);
                newFileList.Add(newFile);
                files.Add(root, newFileList);
            }
            else
            {
                var currentFileList = files[root];
                bool exist = false;

                for (int i = 0; i < currentFileList.Count; i++)
                {
                    File currentFile = currentFileList[i];

                    if (currentFile.name.Equals(filename))
                    {
                        exist = true;
                        currentFile.size = size;
                        break;
                    }
                }

                if (!exist)
                {
                    File newFile1 = new File(filename, size);
                    currentFileList.Add(newFile1);
                }

                files[root] = currentFileList;
            }
        }
    }
}
