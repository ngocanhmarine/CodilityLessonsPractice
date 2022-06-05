using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CodilityLesson14_NailingPlanks
{
    class Program
    {
        #region Brute force
        public static int solution(int[] A, int[] B, int[] C)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> a = new List<int>(A);
            List<int> b = new List<int>(B);
            for (int i = 0; i < C.Length; i++)
            {
                for (int j = a.Count - 1; j >= 0; j--)
                {
                    if (C[i] >= a[j] && C[i] <= b[j])
                    {
                        a.RemoveAt(j);
                        b.RemoveAt(j);
                    }
                }
                if (a.Count == 0)
                {
                    return i + 1;
                }
            }
            return -1;
        }
        #endregion

        public class Nail : IComparable<Nail>
        {
            public readonly int index;
            public readonly int value;

            public Nail(int index, int value)
            {
                this.index = index;
                this.value = value;
            }

            public int CompareTo(Nail other)
            {
                return value - other.value;
            }
        }
        public class Plank : IComparable<Plank>
        {
            public readonly int begin;
            public readonly int end;

            public Plank(int begin, int end)
            {
                this.begin = begin;
                this.end = end;
            }
            public int CompareTo(Plank other)
            {
                return begin - other.begin;
            }
        }
        public static int solution2(int[] A, int[] B, int[] C)
        {
            List<Nail> nails = new List<Nail>();
            HashSet<int> uniqueNails = new HashSet<int>();
            for (int i = 0; i < C.Length; i++)
            {
                if (!uniqueNails.Contains(C[i]))
                {
                    nails.Add(new Nail(i + 1, C[i]));
                    uniqueNails.Add(C[i]);
                }
            }
            nails.Sort();

            List<Plank> planks = new List<Plank>();
            for (int i = 0; i < A.Length; i++)
            {
                planks.Add(new Plank(A[i], B[i]));
            }
            planks.Sort();

            for (int i = 0; i < planks.Count - 2; i++)
            {
                while (i > 0 && planks[i].end > planks[i + 1].end)
                {
                    planks.RemoveAt(i--);
                }
            }

            int max = -1;
            for (int i = 0; i < planks.Count; i++)
            {
                int minNail = FindMinNail(nails, planks[i]);
                if (minNail == -1)
                {
                    return -1;
                }
                max = Math.Max(max, minNail);
            }
            return max;
        }
        public static int FindMinNail(List<Nail> nails, Plank plank)
        {
            int begin = 0;
            int end = nails.Count - 1;
            int firstResult = -1;
            while (begin <= end)
            {
                int mid = (begin + end) / 2;
                if (plank.begin > nails[mid].value)
                {
                    begin = mid + 1;
                }
                else if (plank.end < nails[mid].value)
                {
                    end = mid - 1;
                }
                else
                {
                    firstResult = mid;
                    end = mid - 1;
                }
            }
            if (firstResult == -1)
            {
                return firstResult;
            }
            int res = nails[firstResult].index;
            for (int i = firstResult + 1; i < nails.Count; i++)
            {
                if (nails[i].value <= plank.end)
                {
                    res = Math.Min(res, nails[i].index);
                }
                else
                {
                    return res;
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution2(new int[] { 1, 4, 5, 8 }, new int[] { 4, 5, 9, 10 }, new int[] { 4, 6, 7, 10, 2 }));//4
            Console.WriteLine(solution2(new int[] { 1 }, new int[] { 2 }, new int[] { 2 }));//1
        }
    }
}
