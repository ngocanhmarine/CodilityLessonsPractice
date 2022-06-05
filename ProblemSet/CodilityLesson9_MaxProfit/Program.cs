using System;
using System.Collections.Generic;

namespace CodilityLesson9_MaxProfit
{
    class Program
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> a = new List<int>(A);
            int profit = 0;
            int lowest = -1;
            for (int i = 0; i < a.Count; i++)
            {
                if (lowest == -1)
                {
                    lowest = A[i];
                }
                if (A[i] < lowest)
                {
                    lowest = A[i];
                }
                if (A[i] - lowest > 0)
                {
                    profit = Math.Max(profit, A[i] - lowest);
                }
            }
            return profit;

        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 23171, 21011, 21123, 21366, 21013, 21367 }));//356
        }
    }
}
