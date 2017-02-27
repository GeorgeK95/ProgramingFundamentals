using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Dragon_Army
{
    class Program
    {
        private static Dictionary<string, SortedDictionary<string, int[]>> barrack = new Dictionary<string, SortedDictionary<string, int[]>>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] splitted = line.Split(' ');

                AddStatsToBarrack(splitted);
            }

            PrintBarrack();
        }

        private static void PrintBarrack()
        {
            foreach (var type in barrack)
            {
                double avgDamage = 0;
                double avgHealth = 0;
                double avgArmor = 0;
                double delitel = type.Value.Count;

                foreach (var stat in type.Value)
                {
                    avgDamage += stat.Value[0];
                    avgHealth += stat.Value[1];
                    avgArmor += stat.Value[2];
                }

                avgDamage = Math.Round(avgDamage / (delitel), 2);
                avgHealth = Math.Round(avgHealth / delitel, 2);
                avgArmor = Math.Round(avgArmor / delitel, 2);

                Console.WriteLine("{0:f2}::({1:f2}/{2:f2}/{3:f2})", type.Key, avgDamage, avgHealth, avgArmor);

                foreach (var stat in type.Value)
                {
                    Console.WriteLine($"-{stat.Key} -> damage: {stat.Value[0]}, health: {stat.Value[1]}, armor: {stat.Value[2]}");
                }


            }
        }

        private static void AddStatsToBarrack(string[] splitted)
        {
            string type = splitted[0];
            string name = splitted[1];
            int damage = GetDamage(splitted[2]);
            int health = GetHealth(splitted[3]);
            int armor = GetArmor(splitted[4]);

            if (!barrack.ContainsKey(type))
            {
                SortedDictionary<string, int[]> newStats = new SortedDictionary<string, int[]>();
                int[] statsArray = new int[3];
                statsArray[0] = damage;
                statsArray[1] = health;
                statsArray[2] = armor;
                newStats.Add(name, statsArray);
                barrack.Add(type, newStats);
            }
            else
            {
                SortedDictionary<string, int[]> prev = barrack[type];
                int[] prevStatsArray = new int[3];
                prevStatsArray[0] = damage;
                prevStatsArray[1] = health;
                prevStatsArray[2] = armor;

                if (!prev.ContainsKey(name))
                {
                    prev.Add(name, prevStatsArray);
                    barrack[type] = prev;
                }
                else
                {
                    int[] newStatsArray = prev[name];
                    newStatsArray[0] = damage;
                    newStatsArray[1] = health;
                    newStatsArray[2] = armor;
                    prev[name] = newStatsArray;
                    barrack[type] = prev;
                }

            }

        }

        private static int GetArmor(string v)
        {
            int returnValue = 0;

            if (!v.Equals("null"))
            {
                returnValue = int.Parse(v);
            }
            else
            {
                returnValue = 10;
            }

            return returnValue;
        }

        private static int GetHealth(string v)
        {
            int returnValue = 0;

            if (!v.Equals("null"))
            {
                returnValue = int.Parse(v);
            }
            else
            {
                returnValue = 250;
            }

            return returnValue;
        }

        private static int GetDamage(string v)
        {
            int returnValue = 0;

            if (!v.Equals("null"))
            {
                returnValue = int.Parse(v);
            }
            else
            {
                returnValue = 45;
            }

            return returnValue;
        }
    }
}
