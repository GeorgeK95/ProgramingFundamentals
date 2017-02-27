using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Nether_Realms
{
    class Program
    {
        static List<Animal> stats = new List<Animal>();

        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string line = Console.ReadLine();
            string[] animals = GetAnimals(line);

            for (int i = 0; i < animals.Length; i++)
            {
                string name = animals[i];
                int health = CalculateHealth(animals[i]);
                double damage = CalculateDamage(animals[i]);

                Animal currAnimal = new Animal(name, health, damage);
                stats.Add(currAnimal);
            }

            Print();
        }

        private static void Print()
        {
            stats = stats.OrderBy(x => x.animalName).ToList();

            foreach (var anim in stats)
            {
                Console.WriteLine($"{anim.animalName} - {anim.health} health, {anim.damage:0.00} damage");
            }
        }

        private static double CalculateDamage(string v)
        {
            string pat = @"[\-\+]?[\d]+(?:[\.]*[\d]+|[\d]*)";
            MatchCollection a = Regex.Matches(v, pat);
            double res = 0;

            for (int i = 0; i < a.Count; i++)
            {
                double curr = double.Parse(a[i].ToString());
                res += curr;
            }

            double multi = GetMultiplier(v);
            res *= multi;
            return res;
        }

        private static double GetMultiplier(string v)
        {
            string pat = @"[\*\/]";
            MatchCollection a = Regex.Matches(v, pat);
            double res = 1;

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].ToString().Equals("*"))
                {
                    res *= 2;
                }
                else
                {
                    res /= 2;
                }
            }

            return res;
        }


        private static int CalculateHealth(string v)
        {
            string pattern = @"[^\d\+\-\.\*\/]";
            int res = 0;
            MatchCollection mc = Regex.Matches(v, pattern);

            for (int i = 0; i < mc.Count; i++)
            {
                res += (int)char.Parse(mc[i].ToString());
            }

            return res;
        }

        private static string[] GetAnimals(string line)
        {
            string[] spl = line.Split(new char[] { ' ', ',' , '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return spl;
        }
    }
    class Animal
    {
        public string animalName;
        public double health;
        public double damage;

        public Animal(string animalName, double health, double damage)
        {
            this.animalName = animalName;
            this.health = health;
            this.damage = damage;
        }
    }
}
