using System;
using System.Collections.Generic;

namespace CodilityLesson6_NumberOfDiscIntersections
{
    class Program
    {
        public static int solution1(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int count = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    long dist = Math.Abs(i - j);
                    long R = Math.Max(A[i], A[j]);
                    long r = Math.Min(A[i], A[j]);
                    if (i != j && dist <= R + r)
                    {
                        count++;
                        if (count == 10000000)
                        {
                            return -1;
                        }
                    }
                }
            }
            return count;
        }
        public static int solution2(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<long> start = new List<long>(new long[A.Length]);
            List<long> end = new List<long>(new long[A.Length]);
            for (int i = 0; i < A.Length; i++)
            {
                start[i] = (long)i - A[i];
                end[i] = (long)i + A[i];
            }
            start.Sort();
            end.Sort();
            int si = 0, ei = 0, oc = 0, r = 0;
            while (si < A.Length)
            {
                if (start[si] <= end[ei])
                {
                    oc++;
                    r += oc - 1;
                    if (r > 10000000)
                    {
                        return -1;
                    }
                    si++;
                }
                else
                {
                    oc--;
                    ei++;
                }
            }
            return r;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution2(new int[] { 1, 5, 2, 1, 4, 0 }));//11
            Console.WriteLine(solution2(new int[] { 1, 2147483647, 0 }));//2
        }
    }
}
