using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Dragon_Army
{
    class Stats
    {
        public double damage { get; set; }
        public double health { get; set; }
        public double armor { get; set; }

        public Stats(double damage, double health, double armor)
        {
            this.damage = damage;
            this.health = health;
            this.armor = armor;
        }
        public Stats()
        { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, Stats>> dragons = new Dictionary<string, Dictionary<string, Stats>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string type = GetType(line);
                string name = GetName(line);
                Stats stats = GetStats(line);

                AddDragonToDict(dragons, type, name, stats);
            }

            Print(dragons);
        }

        private static void Print(Dictionary<string, Dictionary<string, Stats>> dragons)
        {
            foreach (var type in dragons)
            {
                double typeDamage = GetTypeDamage(type.Value) / type.Value.Values.Count;
                double typeHealth = GetTypeHealth(type.Value) / type.Value.Values.Count;
                double typeArmor = GetTypeArmor(type.Value) / type.Value.Values.Count;

                Console.WriteLine($"{type.Key}::({ string.Format("{0:0.00}", typeDamage)}/{ string.Format("{0:0.00}", typeHealth)}/{ string.Format("{0:0.00}", typeArmor)})");

                foreach (var name in type.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{name.Key} -> damage: {name.Value.damage}, health: {name.Value.health}, armor: {name.Value.armor}");
                }
            }
        }

        private static double GetTypeArmor(Dictionary<string, Stats> value)
        {
            double armor = 0;

            foreach (var name in value)
            {
                armor += name.Value.armor;
            }

            return armor;
        }

        private static double GetTypeHealth(Dictionary<string, Stats> value)
        {
            double health = 0;

            foreach (var name in value)
            {
                health += name.Value.health;
            }

            return health;
        }

        private static double GetTypeDamage(Dictionary<string, Stats> value)
        {
            double damage = 0;

            foreach (var name in value)
            {
                damage += name.Value.damage;
            }

            return damage;
        }

        private static void AddDragonToDict(Dictionary<string, Dictionary<string, Stats>> dragons, string type, string name, Stats stats)
        {
            if (dragons.ContainsKey(type))
            {
                Dictionary<string, Stats> temp = dragons[type];

                if (temp.ContainsKey(name))
                {
                    Stats old = temp[name];
                    FillCurrentStatsObject(old, stats);
                    temp[name] = old;
                }
                else
                {
                    Stats newStats = new Stats();
                    FillCurrentStatsObject(newStats, stats);
                    temp[name] = newStats;   
                }
                dragons[type] = temp;
            }
            else
            {
                Stats newStats = new Stats();
                FillCurrentStatsObject(newStats, stats);
                Dictionary<string, Stats> newDict = new Dictionary<string, Stats>();
                newDict.Add(name, newStats);
                dragons.Add(type, newDict);
            }
        }

        private static void FillCurrentStatsObject(Stats old, Stats stats)
        {
            if (stats.damage.Equals("null"))
            {
                old.damage = 45;
            }
            else
            {
                old.damage = stats.damage;
            }
            if (stats.health.Equals("null"))
            {
                old.health = 250;
            }
            else
            {
                old.health = stats.health;
            }
            if (stats.armor.Equals("null"))
            {
                old.armor = 10;
            }
            else
            {
                old.armor = stats.armor;
            }
        }

        private static Stats GetStats(string line)
        {
            string[] splitted = line.Split(' ');

            double damage = 0;
            double health = 0;
            double armor = 0;

            if (splitted[2].Equals("null"))
            {
                damage = 45;
            }
            else
            {
                damage = double.Parse(splitted[2]);
            }
            if (splitted[3].Equals("null"))
            {
                health = 250;
            }
            else
            {
                health = double.Parse(splitted[3]);
            }
            if (splitted[4].Equals("null"))
            {
                armor = 10;
            }
            else
            {
                armor = double.Parse(splitted[4]);
            }

            Stats stats = new Stats(damage, health, armor);
            return stats;
        }

        private static string GetName(string line)
        {
            string[] splitted = line.Split(' ');
            return splitted[1];
        }

        private static string GetType(string line)
        {
            string[] splitted = line.Split(' ');
            return splitted[0];
        }

    }
}
