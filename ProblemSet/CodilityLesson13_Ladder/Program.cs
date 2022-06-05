using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson13_Ladder
{
    class Program
    {
        private static double[] factTil(int N)
        {
            double[] r = new double[N + 1];
            r[1] = 1;
            for (int i = 2; i <= N; i++)
            {
                r[i] = r[i - 1] * i;
            }
            return r;
        }
        public static int[] solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            double[] factorial = factTil(A.Max());
            List<int> resultSets = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                double res = 1;
                for (int j = A[i] - 1; j > A[i] / (double)2; j--)
                {
                    int oneCount = A[i] - (A[i] - j) * 2;
                    res += factorial[j] / factorial[j - oneCount] / factorial[oneCount];
                }
                if (A[i] % 2 == 0) res++;
                resultSets.Add((int)(res % ((int)Math.Pow(2, B[i]))));
            }
            return resultSets.ToArray();
        }
        private static int[] fibList(int N)
        {
            int[] fib = new int[N + 1];
            fib[0] = 1;
            fib[1] = 1;
            int limit = (int)Math.Pow(2, 30);
            for (int i = 2; i < N + 1; i++)
            {
                fib[i] = (fib[i - 1] + fib[i - 2]) % limit;
            }
            return fib;
        }
        public static int[] solution2(int[] A, int[] B)
        {
            int[] fib = fibList(A.Max());
            List<int> resultSets = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                int res = fib[A[i]];
                resultSets.Add((int)(res % ((int)Math.Pow(2, B[i]))));
            }
            return resultSets.ToArray();
        }
        static void Main(string[] args)
        {
            List<int[]> resultSets = new List<int[]>();
            int[] result;
            result = solution2(new int[] { 6 }, new int[] { 6 });//13
            resultSets.Add(result);
            result = solution2(new int[] { 11 }, new int[] { 13 });//144
            resultSets.Add(result);
            result = solution2(new int[] { 14 }, new int[] { 10 });//610
            resultSets.Add(result);
            result = solution2(new int[] { 100 }, new int[] { 19 });//458752
            resultSets.Add(result);
            result = solution2(new int[] { 4, 4, 5, 5, 1 }, new int[] { 3, 2, 4, 3, 1 });//5,1,8,0,1
            resultSets.Add(result);

            for (int i = 0; i < resultSets.Count; i++)
            {
                for (int j = 0; j < resultSets[i].Length; j++)
                {
                    Console.Write(resultSets[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
