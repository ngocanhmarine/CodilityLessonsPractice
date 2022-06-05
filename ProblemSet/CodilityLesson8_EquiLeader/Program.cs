using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson8_EquiLeader
{
    class Program
    {
        public static int solution(int[] A)
        {
            int r = 0;
            Dictionary<int, int> a = new Dictionary<int, int>();
            Dictionary<int, int> b = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                b[A[i]] = b.ContainsKey(A[i]) ? b[A[i]] + 1 : 1;
            }
            for (int i = 0; i < A.Length; i++)
            {
                a[A[i]] = a.ContainsKey(A[i]) ? a[A[i]] + 1 : 1;
                b[A[i]]--;
                int am = a.FirstOrDefault(x => x.Value == a.Values.Max()).Key;
                int bm = b.FirstOrDefault(x => x.Value == b.Values.Max()).Key;
                if (am == bm && a[am] > (i + 1) / 2 && b[bm] > (A.Length - 1 - i) / 2)
                {
                    r++;
                }
            }
            return r;
            // write your code in C# 6.0 with .NET 4.5 (Mono)
        }
        public static int solution2(int[] A)
        {
            List<int> a = A.OrderBy(x => x).ToList();
            int result = 0;
            int leaderCount = 0;
            int leaderIndex = -1;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == a[(a.Count - 1) / 2])
                {
                    leaderCount++;
                    if (leaderCount > a.Count / 2)
                    {
                        leaderIndex = a[i];
                    }
                }
            }
            if (leaderIndex != -1)
            {
                int countLeft = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] == leaderIndex)
                    {
                        countLeft++;
                    }
                    if (2 * countLeft > i + 1 && 2 * (leaderCount - countLeft) > (A.Length - i - 1))
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(solution2(new int[] { 4, 3, 4, 4, 4, 2 }));//2
            //Console.WriteLine(solution2(new int[] { 4, 4, 2, 5, 3, 4, 4, 4 }));//3
            Console.WriteLine(solution2(new int[] { 2,-1,4,4,7,-2,4,9,4,4,1,4,4,4,4,4,4,4 }));//
        }
    }
}
