using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Hornet_Assault
{
    class Program
    {

        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine().Split().Select(long.Parse).ToList();
            List<long> hornets = Console.ReadLine().Split().Select(long.Parse).ToList();
            DoHornetAssault(hornets, beehives);
            Print(beehives, hornets);
        }

        private static void DoHornetAssault(List<long> hornets, List<long> beehives)
        {
            int index = beehives.Count;
            for (int i = 0; i < beehives.Count; i++)
            {
                if (hornets.Count == 0)
                {
                    break;
                }

                long hornetsCurrentPower = hornets.Sum();

                if (hornetsCurrentPower > beehives[i])
                {
                    beehives.Remove(beehives[i]);
                    i--;
                }
                else if (hornetsCurrentPower < beehives[i])
                {
                    hornets.RemoveAt(0);
                    beehives[i] -= hornetsCurrentPower;
                }
                else
                {
                    hornets.RemoveAt(0);
                    beehives.Remove(beehives[i]);
                    i--;
                }

                index--;
                if (index == 0)
                {
                    break;
                }
            }
        }

        private static void Print(List<long> beehives, List<long> hornets)
        {
            if (beehives.Count > 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }

    }
}
