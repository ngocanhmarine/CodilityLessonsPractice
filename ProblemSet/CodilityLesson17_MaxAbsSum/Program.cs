using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson17_MaxAbsSum
{
    internal class Program
    {
        public static int getMinAbsSum(List<int> a, int currentSum, Dictionary<string, int> memo)
        {
            string key = a.Count.ToString() + "," + currentSum.ToString();
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }
            if (a.Count == 0)
            {
                return currentSum;
            }
            int next = a[0];
            int add = getMinAbsSum(a.GetRange(1, a.Count - 1), currentSum + next, memo);
            int sub = getMinAbsSum(a.GetRange(1, a.Count - 1), currentSum - next, memo);
            memo.Add(key, Math.Min(Math.Abs(add), Math.Abs(sub)));
            return memo[key];
        }
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> a = A.Select(x => Math.Abs(x)).ToList();
            Dictionary<string, int> memo = new Dictionary<string, int>();

            int smallestSum = getMinAbsSum(a, 0, memo);
            return Math.Abs(smallestSum);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 1, 5, 2, -2 }));//0
            Console.WriteLine(solution(new int[] { -99, 100, 20, 50, -40 }));//9
        }
    }
}
