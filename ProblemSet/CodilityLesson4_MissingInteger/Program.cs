using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson4_MissingInteger
{
    class Program
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> sorted = A.Where(x => x > 0).OrderBy(x => x).Distinct().ToList();
            if (sorted.Count == 0)
            {
                return 1;
            }
            int? r = null;
            for (int i = 0; i < sorted.Count; i++)
            {
                if (sorted[i] != i + 1)
                {
                    r = i + 1;
                    break;
                }
            }
            return r == null ? sorted.Count + 1 : (int)r;
        }
        static void Main(string[] args)
        {
            List<int> test = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                test.Add(i + 1);
            }
            int[] testArr = test.ToArray();
            DateTime start = DateTime.Now;
            Console.WriteLine(solution(new int[] { 1, 3, 6, 4, 1, 2 }));
            //Console.WriteLine(solution(testArr));
            Console.WriteLine($"Time consumed: {(DateTime.Now - start).TotalMilliseconds}ms.");
        }
    }
}
