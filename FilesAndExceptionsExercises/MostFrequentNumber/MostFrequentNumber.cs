using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    class MostFrequentNumber
    {
        static void Main(string[] args)
        {
            File.Delete(@"..\..\..\Output\output_1.txt");

            int[] input = File.ReadAllText("input.txt").Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                
            Dictionary<int, int> nums = new Dictionary<int, int>();

            foreach (var num in input)
            {
                if (nums.ContainsKey(num))
                {
                    nums[num]++;
                }
                else
                {
                    nums.Add(num, 1);
                }
            }

            File.WriteAllText(@"..\..\..\Output\output_1.txt", nums.First(x => x.Value == nums.Values.Max()).Key.ToString());
        }
    }
}
