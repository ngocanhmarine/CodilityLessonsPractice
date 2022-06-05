using System;
using System.Collections.Generic;

namespace CodilityLesson15_CountDistinctSlices
{
    class Program
    {
        public static int solution(int M, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = 0;
            HashSet<int> temp = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                temp.Clear();
                temp.Add(A[i]);
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (temp.Contains(A[j]))
                    {
                        break;
                    }
                    temp.Add(A[j]);
                }
                result += temp.Count;
            }

            return result;
        }
        public static int solution2(int M, int[] A)
        {
            List<int> temp = new List<int>() { A[0] };
            int result = 0;
            int end = 0;
            while (end < A.Length - 1)
            {

                if (end < A.Length - 1 && temp.Contains(A[end + 1]))
                {
                    result += temp.Count;
                    temp.RemoveAt(0);
                    continue;
                }
                end++;
                temp.Add(A[end]);
                if (end == A.Length - 1)
                {
                    result += (int)((temp.Count + 1) * (double)temp.Count / 2);
                }
            }
            return result;
        }
        public static int solution3(int M, int[] A)
        {
            HashSet<int> temp = new HashSet<int>();
            int start = 0;
            int end = 0;
            int result = 0;
            while (A.Length > start || A.Length > end)
            {
                if (A.Length > end && !temp.Contains(A[end]))
                {
                    temp.Add(A[end]);
                    end++;
                    result += temp.Count;
                    if (result >= 1000000000)
                    {
                        return 1000000000;
                    }
                }
                else
                {
                    temp.Remove(A[start]);
                    start++;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution3(6, new int[] { 3, 4, 5, 5, 2 }));//9

            int maxInt = 100000;
            int[] testArr = new int[100000];
            for (int i = 0; i < testArr.Length; i++)
            {
                testArr[i] = new Random().Next(0, maxInt);
            }
            DateTime t1 = DateTime.Now;
            Console.WriteLine(solution3(maxInt, testArr));
            DateTime t2 = DateTime.Now;
            Console.WriteLine($"Time consumed: {(t2 - t1).TotalMilliseconds}ms.");
        }
    }
}
