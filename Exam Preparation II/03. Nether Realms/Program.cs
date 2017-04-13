using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Nether_Realms
{
    class Demon
    {
        public string name { get; set; }
        public int health { get; set; }
        public double damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] demons = GetDemons(input);
            List<Demon> demonsList = new List<Demon>();

            for (int i = 0; i < demons.Length; i++)
            {
                string currentDemon = demons[i];
                int health = GetDemonHealth(currentDemon);
                double damage = CalculateDamage(currentDemon);

                Demon demon = new Demon(demons[i], health, damage);
                demonsList.Add(demon);
            }

            PrintDemons(demonsList);
        }

        private static string[] GetDemons(string line)
        {
            string[] spl = line.Split(new char[] { ' ', ',', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return spl;
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

            double multi = GetMultyDivideOperations(v);
            res *= multi;
            return res;
        }

        private static double GetMultyDivideOperations(string currentDemon)
        {
            string pat = @"[\*\/]";
            MatchCollection matches = Regex.Matches(currentDemon, pat);
            double res = 1;

            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].ToString().Equals("*"))
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

        private static string ReplaceWordsWithSpaces(string currentDemon)
        {
            Regex reg = new Regex(@"[a-zA-Z]");
            currentDemon = reg.Replace(currentDemon, " ");
            return currentDemon;
        }

        private static int GetDemonHealth(string currentDemon)
        {
            string pattern = @"[^\d\+\-\.\*\/]";
            int res = 0;
            MatchCollection mc = Regex.Matches(currentDemon, pattern);

            for (int i = 0; i < mc.Count; i++)
            {
                res += (int)char.Parse(mc[i].ToString());
            }

            return res;
        }

        private static string RemoveSpaces(string input)
        {
            return input.Replace(" ", "");
        }

        private static void PrintDemons(List<Demon> demonsList)
        {
            foreach (var demon in demonsList.OrderBy(x => x.name))
            {
                Console.WriteLine($"{demon.name} - {demon.health} health, {demon.damage:F2} damage");
            }
        }
    }
}
