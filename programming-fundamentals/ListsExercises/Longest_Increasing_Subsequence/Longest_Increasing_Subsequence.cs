using System;
using System.Collections.Generic;
using System.Linq;

namespace Longest_Increasing_Subsequence
{
    class LongestIncreasingSubsequence
    {
        static void Main(string[] args)
        {
            int [] numbers = Console.ReadLine()
                .Split(' ')
                .Select(x=>int.Parse(x))
                .ToArray();
            int[] longestSequence = FindLIS(numbers);
            Console.WriteLine(string.Join(" ", longestSequence));


        }
        public static int[] FindLIS(int[] sequence)
        {
            int[] len = new int[sequence.Length];
            int[] prev = new int[sequence.Length];
            int maxLength = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && len[j] >= len[i])
                    {
                        len[i] = 1 + len[j];
                        prev[i] = j;
                    }
                }

                if (len[i] > maxLength)
                {
                    maxLength = len[i];
                    lastIndex = i;
                }
            }

            var longestSequence = new List<int>();
            for (int i = 0; i < maxLength; i++)
            {
                longestSequence.Add(sequence[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSequence.Reverse();
            return longestSequence.ToArray();
        }
    }
}
