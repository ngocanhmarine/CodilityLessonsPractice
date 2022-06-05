using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson5_MinAverageTwoSlice
{
    class Program
    {
        public static int solution1(int[] A)
        {
            List<int> a = new List<int>(A);
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            double min = double.MaxValue;
            int start = 0;
            for (int i = 1; i < A.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    double avg = a.GetRange(j, i - j + 1).Average();
                    if (avg < min)
                    {
                        min = avg;
                        start = j;
                    }
                }
            }
            return start;
        }
        public static int solution2(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> a = new List<int>(A);
            int[,] m = new int[A.Length, A.Length];
            double min = double.MaxValue;
            int start = 0;
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    m[i, i - j] = ((i - 1 - j >= 0) ? m[i - 1, i - j - 1] : 0) + a[i];
                    if (j < i)
                    {
                        double avg = (double)m[i, i - j] / (i - j + 1);
                        if (min > avg)
                        {
                            min = avg;
                            start = j;
                        }
                    }
                }
            }
            return start;
        }
        public static int solution3(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int start = 0;
            double min = double.MaxValue;
            for (int i = 0; i < A.Length - 1; i++)
            {
                if (i < A.Length - 2)
                {
                    double avg3 = (A[i] + A[i + 1] + A[i + 2]) / (double)3;
                    if (min > avg3)
                    {
                        min = avg3;
                        start = i;
                    }
                }
                double avg2 = (A[i] + A[i + 1]) / (double)2;
                if (avg2 < min)
                {
                    min = avg2;
                    start = i;
                }
            }
            return start;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution3(new int[] { 4, 2, 2, 5, 1, 5, 8 }));
        }
    }
}
