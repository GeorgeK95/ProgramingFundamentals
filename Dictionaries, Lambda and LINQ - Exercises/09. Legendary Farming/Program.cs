using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> goodMaterials = new Dictionary<string, int>();
            goodMaterials.Add("shards", 0);
            goodMaterials.Add("fragments", 0);
            goodMaterials.Add("motes", 0);
            Dictionary<string, int> junk = new Dictionary<string, int>();
            string text = Console.ReadLine().ToLower();
            bool isOver = false;

            while (true)
            {
                text = text.ToLower();

                if (text == null)
                {
                    break;
                }

                string[] splitted = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < splitted.Length; i += 2)
                {
                    int quantity = int.Parse(splitted[i]);
                    string material = splitted[i + 1];

                    if (goodMaterials.ContainsKey(material))
                    {
                        goodMaterials[material] += quantity;

                        if (isLimitReached(goodMaterials))
                        {
                            string winner = GetWinner(goodMaterials);
                            Print(goodMaterials, junk, winner);
                            isOver = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(material))
                        {
                            junk[material] += quantity;
                        }
                        else
                        {
                            junk.Add(material, quantity);
                        }
                    }
                }

                if (isOver)
                {
                    break;
                }
                text = Console.ReadLine().ToLower();
            }
        }

        private static void Print(Dictionary<string, int> goodMaterials, Dictionary<string, int> junk, string winner)
        {
            if (winner.Equals("shards"))
            {
                Console.WriteLine("Shadowmourne" + " obtained!");
            }
            else if (winner.Equals("fragments"))
            {
                Console.WriteLine("Valanyr" + " obtained!");
            }
            else
            {
                Console.WriteLine("Dragonwrath" + " obtained!");
            }
            
            goodMaterials[winner] -= 250;

            foreach (var item in goodMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static string GetWinner(Dictionary<string, int> goodMaterials)
        {
            string retValue = "";

            foreach (var item in goodMaterials)
            {
                if (item.Value >= 250)
                {
                    retValue = item.Key;
                }
            }

            return retValue;
        }

        private static bool isLimitReached(Dictionary<string, int> goodMaterials)
        {
            foreach (var item in goodMaterials)
            {
                if (item.Value >= 250)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
