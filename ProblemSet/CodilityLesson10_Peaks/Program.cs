using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson10_Peaks
{
    class Program
    {
        public static int solution(int[] A)
        {
            List<int> peaks = new List<int>();
            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    peaks.Add(i);
                }
            }
            int maxGroups = (int)Math.Ceiling((double)A.Length / 2);
            for (int i = maxGroups; i > 0; i--)
            {
                if (A.Length % i == 0)
                {
                    int step = A.Length / i;
                    int start = 0;
                    int end = step - 1;
                    bool isContain = false;
                    while (start < A.Length)
                    {
                        isContain = peaks.Where(x => x >= start && x <= end).Any();
                        if (!isContain)
                        {
                            break;
                        }
                        start += step;
                        end += step;
                    }
                    if (!isContain)
                    {
                        continue;
                    }
                    return i;
                }
            }
            return 0;
        }
        public static int solution2(int[] A)
        {
            List<int> peaks = new List<int>();
            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    peaks.Add(i);
                }
            }
            for (int size = 1; size <= A.Length; size++)
            {
                if (A.Length % size != 0)
                {
                    continue;
                }
                int find = 0;
                int groups = A.Length / size;
                bool ok = true;
                for (int i = 0; i < peaks.Count; i++)
                {
                    if (peaks[i] / size > find)
                    {
                        ok = false;
                        break;
                    }
                    if (peaks[i] / size == find) find++;
                }
                if (find != groups) ok = false;
                if (ok) return groups;
            }
            return 0;
        }
        public static int solution3(int[] A)
        {
            List<int> peaks = new List<int>();
            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    peaks.Add(i);
                }
            }
            int maxGroups = (int)Math.Ceiling((double)A.Length / 2);
            for (int i = maxGroups; i > 0; i--)
            {
                if (A.Length % i == 0)
                {
                    int step = A.Length / i;
                    int find = 0;
                    bool isContain = true;
                    for (int j = 0; j < peaks.Count; j++)
                    {
                        if (peaks[j] / step > find)
                        {
                            isContain = false;
                            break;
                        }
                        if (peaks[j] / step == find)
                        {
                            find++;
                        }
                    }
                    if (find != i)
                    {
                        isContain = false;
                    }
                    if (!isContain)
                    {
                        continue;
                    }
                    return i;
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution3(new int[] { 1, 2, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 }));//3
            Console.WriteLine(solution3(new int[] { 1, 3, 2, 1 }));//1
            Console.WriteLine(solution3(new int[] { 1, 2, 5, 7, 9, 13, 1, 2, 1, 2, 1, 2 }));//2
        }
    }
}
