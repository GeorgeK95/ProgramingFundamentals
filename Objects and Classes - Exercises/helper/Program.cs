using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            nums.Add(1); nums.Add(2); nums.Add(3); nums.Add(4); nums.Add(5); nums.Add(6); nums.Add(7); nums.Add(8);

            List<int> evenNumbers = nums.FindAll(x => (x % 2) == 0);
            foreach (var item in evenNumbers)
            {
                nums.Remove(item);
            }

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }
    }
}
