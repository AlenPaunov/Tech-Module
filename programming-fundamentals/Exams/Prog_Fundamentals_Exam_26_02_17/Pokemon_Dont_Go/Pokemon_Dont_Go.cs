using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Dont_Go
{
    class Pokemon_Dont_Go
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            int capturedTargets = 0;
            while (targets.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removedValue;

                if (index > targets.Count - 1)
                {
                    removedValue = targets.Last();
                    targets[targets.Count-1] = targets[0];
                }
                else if (index < 0)
                {
                    removedValue = targets[0];
                    targets[0] = targets.Last();
                }
                else
                {
                    removedValue = targets[index];
                    targets.RemoveAt(index);
                }
                capturedTargets += removedValue;

                for (int i = 0; i<targets.Count; i++)
                {
                    int target = targets[i];
                    if (target<=removedValue)
                    {
                        targets[i] += removedValue;
                    }
                    else
                    {
                        targets[i] -= removedValue;
                    }
                }
            }
            Console.WriteLine(capturedTargets);
        }
    }
}
