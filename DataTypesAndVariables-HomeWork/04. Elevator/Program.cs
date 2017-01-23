using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfPeople = double.Parse(Console.ReadLine());
            double capacity = double.Parse(Console.ReadLine());

            if (numberOfPeople <= capacity)
            {
                Console.WriteLine("All the persons fit inside the elevator.\nOnly one course is needed.");
            }
            else
            {
                Console.WriteLine(Math.Ceiling(numberOfPeople / capacity));
            }
        }
    }
}
