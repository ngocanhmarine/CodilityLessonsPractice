using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson4_PermCheck
{
    class Program
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> sortedA = A.OrderBy(x => x).ToList();
            if (sortedA.Count != sortedA[sortedA.Count - 1])
            {
                return 0;
            }
            for (int i = 0; i < sortedA.Count; i++)
            {
                if (sortedA[i] != i + 1)
                {
                    return 0;
                }
            }
            return 1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 4,2,1,3 }));
        }
    }
}
