using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson7_Fish
{
    class Program
    {
        public static int solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int count = 0;
            List<long> c = new List<long>();

            List<int> b = new List<int>(B);
            int start = b.IndexOf(1);
            if (start == -1 || b.IndexOf(0) == -1)
            {
                return B.Count();
            }
            count = start;

            List<int> a = A.ToList().GetRange(start, A.Length - start);
            b = B.ToList().GetRange(start, A.Length - start);
            for (int i = 0; i < a.Count; i++)
            {
                int v = (b[i] == 0 ? a[i] * -1 : a[i]);
                if (v > 0)
                {
                    c.Add(v);
                }
                else
                {
                    for (int j = c.Count - 1; j >= 0; j--)
                    {
                        if (Math.Abs(c[j]) > Math.Abs(v))
                        {
                            break;
                        }
                        c.RemoveAt(j);
                    }
                    if (c.Count == 0)
                    {
                        count++;
                    }
                }
            }
            count += c.Count();
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 1, 0, 0, 0 }));//2
            Console.WriteLine(solution(new int[] { 0 }, new int[] { 1 }));//1
            Console.WriteLine(solution(new int[] { 2, 3, 5, 6, 2, 5, 7 }, new int[] { 1, 0, 0, 1, 0, 1, 0 }));//3
            Console.WriteLine(solution(new int[] { 2, 3, 5, 6, 2, 5, 7 }, new int[] { 0, 0, 0, 1, 0, 1, 0 }));//4
            Console.WriteLine(solution(new int[] { 2, 3, 5, 6, 2, 5, 7, 1, 2, 3 }, new int[] { 0, 0, 0, 1, 0, 1, 0, 1, 1, 1 }));//7
        }
    }
}
