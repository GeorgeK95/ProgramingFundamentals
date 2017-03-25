using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();

            while (!line.Equals("end"))
            {
                string name = GetName(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2]);
                string ip = GetIp(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);

                if (!data.ContainsKey(name))
                {
                    var temp = new Dictionary<string, int>();
                    temp.Add(ip, 1);
                    data.Add(name, temp);
                }
                else
                {
                    var temp = data[name];

                    if (!temp.ContainsKey(ip))
                    {
                        temp.Add(ip, 1);
                        data[name] = temp;
                    }
                    else
                    {
                        temp[ip]++;
                        data[name] = temp;
                    }
                }

                line = Console.ReadLine();
            }

            Print(data);
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> data)
        {
            foreach (var name in data.OrderBy(x => x.Key))
            {
                Console.WriteLine(name.Key + ": ");
                int limit = name.Value.Count;

                foreach (var ip in name.Value)
                {
                    limit--;
                    Console.Write($"{ip.Key} => {ip.Value}");
                    if (limit == 0)
                    {
                        Console.WriteLine(".");
                    }
                    else
                    {
                        Console.Write(", ");
                    }

                }

            }
        }

        private static string GetName(string v)
        {
            return v.Substring(5);
        }

        private static string GetIp(string v)
        {
            return v.Substring(3);
        }
    }
}
