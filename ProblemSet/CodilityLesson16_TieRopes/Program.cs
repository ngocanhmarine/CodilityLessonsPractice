using System;

namespace CodilityLesson16_TieRopes
{
    class Program
    {
        public static int solution(int K, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int start = 0;
            int end = 0;
            int sum = A[0];
            int count = 0;
            while (start < A.Length && end < A.Length)
            {
                if (sum < K)
                {
                    end++;
                    if (end < A.Length)
                    {
                        sum += A[end];
                    }
                }
                if (sum >= K)
                {
                    count++;
                    start = ++end;
                    if (start < A.Length) sum = A[start];
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(4, new int[] { 1, 2, 3, 4, 1, 1, 3 }));//3
            Console.WriteLine(solution(2, new int[] { 1, 2 }));//2
        }
    }
}
