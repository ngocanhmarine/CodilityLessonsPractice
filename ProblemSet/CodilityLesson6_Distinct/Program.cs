using System;
using System.Collections.Generic;

namespace CodilityLesson6_Distinct
{
    class Program
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            HashSet<int> h = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                h.Add(A[i]);
            }
            return h.Count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution( new int[] { 2,1,1,2,3,1}));
        }
    }
}
