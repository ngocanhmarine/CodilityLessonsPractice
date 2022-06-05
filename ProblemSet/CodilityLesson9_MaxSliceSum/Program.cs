using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson9_MaxSliceSum
{
    class Program
    {
        public static int solution2(int[] A)
        {
            if (A.Max() <= 0)
            {
                return A.Max();
            }
            List<int> finalList = new List<int>();
            if (A.Min() < 0)
            {
                int maxSum = 0;
                List<int> subList = new List<int>();
                for (int i = 0; i < A.Length; i++)
                {
                    bool shouldAdd = false;
                    if (subList.Count > 0)
                    {
                        if ((subList[0] >= 0 && A[i] >= 0) || (subList[0] < 0 && A[i] < 0))
                        {
                            shouldAdd = true;
                        }
                    }
                    if (shouldAdd)
                    {
                        subList.Add(A[i]);
                    }
                    if (!shouldAdd || i == A.Length - 1)
                    {
                        if (subList.Count > 0)
                        {
                            finalList.Add(subList.Sum());
                            subList.Clear();
                        }
                        if (!shouldAdd)
                        {
                            finalList.Add(A[i]);
                        }
                    }
                }
                for (int i = 0; i < finalList.Count; i++)
                {
                    for (int j = i; j < finalList.Count; j++)
                    {
                        int sum = finalList.GetRange(i, j - i + 1).Sum();
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                        }
                    }
                }
                return maxSum;
            }
            else
            {
                return A.Sum();
            }
        }
        public static int solution(int[] A)
        {
            int maxProfit = A[0];
            List<int> a = new List<int>(A);
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i; j < A.Length; j++)
                {
                    int sum = a.GetRange(i, j - i + 1).Sum();
                    if (sum > maxProfit)
                    {
                        maxProfit = sum;
                    }
                }
            }
            return maxProfit;
        }
        public static int solution3(int[] A)
        {
            int maxVal = A[0];
            int sum = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                maxVal = Math.Max(A[i], A[i] + maxVal);
                sum = Math.Max(sum, maxVal);
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution3(new int[] { 3, 2, -6, 4, 0 }));//5
            Console.WriteLine(solution3(new int[] { 3, -2, 3 }));//4
            Console.WriteLine(solution3(new int[] { -1, 4, 5, 3, 7, -1, -5, -4, -5, 2, 4, 1, 2, 3, 4, 3 }));//23
        }
    }
}
