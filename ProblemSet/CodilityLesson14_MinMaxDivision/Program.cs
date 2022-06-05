using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson14_MinMaxDivision
{
    class Program
    {
        public static int solution(int K, int M, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int max = A.Length * M;
            int min = A.Max();
            int result = min;
            while (min <= max)
            {
                int mid = (max + min) / 2;
                if (check(A, mid) <= K)
                {
                    max = mid - 1;
                    result = mid;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return result;
        }
        public static int check(int[] A, int val)
        {
            int k = 1;
            int sum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (sum + A[i] > val)
                {
                    sum = A[i];
                    k++;
                }
                else
                {
                    sum += A[i];
                }
            }
            return k;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(solution(3, 5, new int[] { 2, 1, 5, 1, 2, 2, 2 }));//6
            //Console.WriteLine(solution(2, 5, new int[] { 5, 3 }));//5
            //Console.WriteLine(solution(2, 0, new int[] { 0, 0 }));//0
            Console.WriteLine(solution(6, 5, new int[] { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 }));//0
        }
    }
}
