using System;
using System.Collections.Generic;

namespace CodilityLesson15_AbsDistinct
{
    class Program
    {
        public static int solution(int[] A)
        {
            HashSet<int> a = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                a.Add(A[i] >= 0 ? A[i] : -A[i]);
            }
            return a.Count;
        }
        public static int solution2(int[] A)
        {
            int current = Math.Max(Math.Abs(A[0]), Math.Abs(A[A.Length - 1]));
            int start = 0;
            int end = A.Length - 1;
            int count = 1;
            while (start <= end)
            {
                int startAbs = Math.Abs(A[start]);
                if (startAbs == current)
                {
                    start++;
                    continue;
                }
                int endAbs = Math.Abs(A[end]);
                if (endAbs == current)
                {
                    end--;
                    continue;
                }
                if (startAbs >= endAbs)
                {
                    current = startAbs;
                    start++;
                }
                else
                {
                    current = endAbs;
                    end--;
                }
                count++;
            }
            return count;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(solution2(new int[] { -5, -3, -1, 0, 3, 6 }));//5
            Console.WriteLine(solution2(new int[] { -10 }));//1
        }
    }
}
