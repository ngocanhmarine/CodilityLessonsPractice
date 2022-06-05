using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson17_NumberSolitaire
{
    class Program
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int res = A[0];
            int max = A[1];
            int step = 0;
            int maxIndex = 1;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > 0)
                {
                    step = 0;
                    res += A[i];
                    max = (i == A.Length - 1) ? max : A[i + 1];
                    maxIndex = i;
                }
                else
                {
                    if (i == A.Length - 1)
                    {
                        res += A[i];
                    }
                    else if (step == 5)
                    {
                        step = 0;
                        if (A[i] > max)
                        {
                            maxIndex = i;
                            max = A[i];
                        }
                        i = maxIndex;
                        res += max;
                        max = (i == A.Length - 1) ? max : A[i + 1];
                        maxIndex = i + 1;
                    }
                    else
                    {
                        step++;
                        if (A[i] > max)
                        {
                            maxIndex = i;
                            max = A[i];
                        }
                    }
                }
            }
            return res;
        }
        public static int solution2(int[] A)
        {
            int[] b = new int[A.Length];
            b[0] = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                int max = int.MinValue;
                for (int j = 1; j <= 6; j++)
                {
                    if (i - j >= 0)
                    {
                        max = Math.Max(max, b[i - j]);
                    }
                }
                b[i] = max + A[i];
            }
            return b[A.Length - 1];
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(solution2(new int[] { 1, -2, 0, 9, -1, -2 }));//8
            //Console.WriteLine(solution2(new int[] { 0, -4, -5, -2, -7, -9, -3, -10 }));//-12
            //Console.WriteLine(solution2(new int[] { -8, -1, -3, -5, -9, -3, -7, -3 }));//-12
            Console.WriteLine(solution(new int[] { -3489, 8728, 3202, -1386, -8394, 9416, 2275, 7927, 5709, -1573, -1552, -1895, -3063, 4319, 3285, 4617, -1151, 2110, 3972, 8267, 9938, -3426, -9338, -4869, -1538, 9243, 2541, 7310, -6695, 4800, 5087, 6691, 4311, -5896, -5856, -9628, -1652, -2453, 9660, 2636, 3537, 2698, -9187, -8355, -1358, -2325, -3921, -7461, -2831, -4965, -6967, 728, -4808, -9501, -2272, 4461, 2591, -7405, 4676, 6887, -8600, -511, -853, 5433, -2135, -3719, -1681, 7358, -5300, -2563, -9207, 5826, -3026, 5861, 9254, -8236, -9715, 3541, 1014, 5311, -2312, -5474, -5335, 2794, -3709, 8883, -3976 }));

            //Console.WriteLine();
            //List<int> abc = new List<int>();
            //for (int i = 0; i < 1000; i++)
            //{
            //    abc.Add(new Random().Next(-10000, 10000));
            //    Console.Write(abc.Last() + ",");
            //}
        }
    }
}
