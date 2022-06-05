using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson5_PassingCars
{
    class Program
    {
        public static int solution(int[] A)
        {
            var filtered = A.GroupBy(x => x).Select(x => new { a = x.Key, b = x.Count() }).ToList();
            int westCount = filtered.Where(x => x.a == 1).Select(x => x.b).FirstOrDefault();
            int pairCount = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0 && westCount > 0)
                {
                    pairCount += westCount;
                    if (pairCount > 1000000000)
                    {
                        return -1;
                    }
                }
                else if (A[i] == 1)
                {
                    westCount--;
                }
            }
            return pairCount;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 0, 1, 0, 1, 1 }));
        }
    }
}
