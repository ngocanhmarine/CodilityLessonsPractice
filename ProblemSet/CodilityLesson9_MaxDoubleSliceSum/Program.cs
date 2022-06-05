using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson9_MaxDoubleSliceSum
{
    class Program
    {
        public static int solution(int[] A)
        {
            int s = 1, e = A.Length - 2;
            int sMaxVal = Math.Max(0, A[1]);
            int[] sList = new int[A.Length];
            sList[1] = sMaxVal;
            int eMaxVal = Math.Max(A[A.Length - 2], 0);
            int[] eList = new int[A.Length];
            eList[A.Length - 2] = eMaxVal;

            while (s < A.Length - 1 && e > 0)
            {
                s++;
                e--;
                sMaxVal = Math.Max(0, Math.Max(A[s], sMaxVal + A[s]));
                sList[s] = sMaxVal;
                eMaxVal = Math.Max(0, Math.Max(A[e], eMaxVal + A[e]));
                eList[e] = eMaxVal;
            }
            int maxDSum = 0;
            for (int i = 1; i < sList.Length - 1; i++)
            {
                maxDSum = Math.Max(maxDSum, sList[i - 1] + eList[i + 1]);
            }
            return maxDSum;
        }
        public static int solution2(int[] A)
        {
            int maxDSum = 0;
            List<int> a = new List<int>(A);
            for (int i = 0; i < A.Length - 2; i++)
            {
                for (int j = i + 2; j < A.Length; j++)
                {
                    for (int k = i + 1; k < j; k++)
                    {
                        int sum = a.GetRange(i + 1, k - i + 1).Sum() + a.GetRange(k + 1, j - 1 - k).Sum();
                        maxDSum = Math.Max(sum, maxDSum);
                    }
                }
            }
            return maxDSum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 3, 2, 6, -1, 4, 5, -1, 2 }));//17
            Console.WriteLine(solution(new int[] { 5, 17, 0, 3 }));//17
            Console.WriteLine(solution(new int[] { 5, 8, -9, -8, 17, 0, 3 }));//17
            Console.WriteLine(solution(new int[] { 0, 10, -5, -2, 0 }));//10
        }
    }
}
