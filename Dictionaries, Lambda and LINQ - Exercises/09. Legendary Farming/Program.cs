using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Legendary_Farming
{
    class Program
    {
        private static SortedDictionary<string, int> materials = new SortedDictionary<string, int>();
        private static SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            // string[] splitted = input.Split(' ');
            string winMaterial = string.Empty;

            materials.Add("fragments", 0);
            materials.Add("shards", 0);
            materials.Add("motes", 0);
            bool limit = true;

            while (limit)
            {
                string[] splitted = input.Split(' ');

                for (int i = 0; i < splitted.Length; i += 2)
                {
                    int quantity = int.Parse(splitted[i]);
                    string material = splitted[i + 1].ToLower();

                    AddMaterialsInDictionaries(quantity, material);

                    if (IsRaceOver())
                    {
                        winMaterial = material;
                        limit = false;
                        break;
                    }
                }

                input = Console.ReadLine();
            }

            PrintFinalResult(winMaterial);
        }

        private static void PrintFinalResult(string winMaterial)
        {
            var sortedMaterials = materials.OrderByDescending(pair => pair.Value);
            Print(winMaterial, sortedMaterials);
        }

        private static void Print(string winMaterial, IOrderedEnumerable<KeyValuePair<string, int>> sortedMaterials)
        {
            string reward = string.Empty;

            switch (winMaterial)
            {
                case "shards":
                    reward = "Shadowmourne";
                    break;
                case "fragments":
                    reward = "Valanyr";
                    break;
                case "motes":
                    reward = "Dragonwrath";
                    break;
            }

            if (winMaterial != null)
            {
                Console.WriteLine($"{reward} obtained!");
            }

            foreach (var currentMaterial in sortedMaterials)
            {
                Console.WriteLine($"{currentMaterial.Key}: {currentMaterial.Value}");
            }
            foreach (var currentJunkMaterial in junk)
            {
                Console.WriteLine($"{currentJunkMaterial.Key}: {currentJunkMaterial.Value}");
            }
        }

        private static bool IsRaceOver()
        {
            foreach (var item in materials)
            {
                if (item.Value >= 250)
                {
                    materials[item.Key] = item.Value - 250;
                    return true;
                }
            }
            return false;
        }

        private static void AddMaterialsInDictionaries(int quantity, string material)
        {
            if (material.Equals("shards") || material.Equals("fragments") || material.Equals("motes"))
            {
                int oldVal = materials[material];
                int newVal = oldVal + quantity;
                materials[material] = newVal;
            }
            else
            {
                if (junk.ContainsKey(material))
                {
                    int oldVal = junk[material];
                    int newVal = oldVal + quantity;
                    junk[material] = newVal;
                }
                else
                {
                    junk.Add(material, quantity);
                }
            }
        }
    }
}
