using System;

namespace CodilityLesson16_MaxNonoverlappingSegments
{
    class Program
    {
        public static int solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length == 0)
            {
                return 0;
            }
            int end = B[B.Length - 1];
            int start = A[A.Length - 1];
            int count = 1;
            for (int i = B.Length - 2; i >= 0; i--)
            {
                if (B[i] < start)
                {
                    count++;
                    start = A[i];
                    end = B[i];
                }
                else if (B[i] <= end && A[i] >= start)
                {
                    end = B[i];
                    start = A[i];
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 1, 3, 7, 9, 9 }, new int[] { 5, 6, 8, 9, 10 }));
        }
    }
}
