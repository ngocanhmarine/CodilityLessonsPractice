using System;
using System.Collections.Generic;

namespace CodilityLesson13_FibFrog
{
    class Program
    {
        private static int isFibCollection(List<int> a, int sum, List<int> fibList)
        {
            if (sum == 0)
            {
                return -1;
            }
            if (fibList.Contains(sum))
            {
                return 1;
            }
            int leftSum = sum;
            int result = -1;
            for (int i = a.Count - 1; i >= 0; i--)
            {
                leftSum -= a[i];
                if (leftSum == 0)
                {
                    continue;
                }
                int left = isFibCollection(a.GetRange(0, i), leftSum, fibList);
                int right = isFibCollection(a.GetRange(i, a.Count - i), sum - leftSum, fibList);
                if (left != -1 && right != -1)
                {
                    if (result == -1 || result > left + right)
                    {
                        result = left + right;
                    }
                }
            }
            return result;
        }
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int maxStep = A.Length + 1;
            List<int> fibMax = new List<int>() { 0, 1 };
            while (fibMax[fibMax.Count - 1] <= maxStep)
            {
                fibMax.Add(fibMax[fibMax.Count - 1] + fibMax[fibMax.Count - 2]);
            }
            int currentPosition = -1;
            int iter = 0;
            List<int> steps = new List<int>();
            while (iter <= A.Length)
            {
                if (iter == A.Length || A[iter] == 1)
                {
                    steps.Add(iter - currentPosition);
                    currentPosition = iter;
                }
                iter++;
            }

            return isFibCollection(steps, maxStep, fibMax);
        }
        public static int solution2(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> a = new List<int>(A);
            a.Add(1);
            int maxStep = a.Count;
            List<int> fibMax = new List<int>() { 0, 1 };
            while (fibMax[fibMax.Count - 1] <= maxStep)
            {
                fibMax.Add(fibMax[fibMax.Count - 1] + fibMax[fibMax.Count - 2]);
            }
            fibMax.RemoveAt(0);
            fibMax.RemoveAt(0);
            int[] reachSteps = new int[maxStep];
            for (int i = 0; i < fibMax.Count; i++)
            {
                if (fibMax[i] > a.Count)
                {
                    break;
                }
                if (a[fibMax[i] - 1] == 1)
                {
                    reachSteps[fibMax[i] - 1] = 1;
                }
            }
            for (int i = 0; i < maxStep; i++)
            {
                if (reachSteps[i] > 0 || a[i] == 0)
                {
                    continue;
                }
                int min_i = -1;
                int min_val = 100000;
                for (int j = 0; j < fibMax.Count; j++)
                {
                    int prevI = i - fibMax[j];
                    if (prevI < 0)
                    {
                        break;
                    }
                    if (reachSteps[prevI] > 0 && min_val > reachSteps[prevI])
                    {
                        min_val = reachSteps[prevI];
                        min_i = prevI;
                    }
                }
                if (min_i != -1)
                {
                    reachSteps[i] = min_val + 1;
                }
            }
            if (reachSteps[maxStep - 1] > 0)
            {
                return reachSteps[maxStep - 1];
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(solution2(new int[] { 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0 }));//3
            Console.WriteLine(solution2(new int[] { 1, 1, 0, 0, 0 }));//2
            Console.WriteLine(solution2(new int[] { 0, 0, 1, 0, 0, 0, 1, 1, 1, 1 }));//2
        }
    }
}
