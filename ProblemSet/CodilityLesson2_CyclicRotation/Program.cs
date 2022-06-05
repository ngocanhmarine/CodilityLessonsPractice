using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson2_CyclicRotation
{
    class Program
    {
        public static int[] solution(int[] A, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (!A.Any() || K == 0)
            {
                return A;
            }
            K = K % A.Length;
            List<int> a = new List<int>(A);
            int[] B = new int[A.Length];
            List<int> r = a.GetRange(A.Length - K, K).Concat(a.GetRange(0, A.Length - K)).ToList();
            return r.ToArray();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 3, 8, 9, 7, 6 }, 3));
        }
    }
}
