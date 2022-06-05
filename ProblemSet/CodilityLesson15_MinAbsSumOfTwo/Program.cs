using System;
using System.Collections.Generic;

namespace CodilityLesson15_MinAbsSumOfTwo
{
    class Program
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length == 1) return Math.Abs(2 * A[0]);
            List<int> a = new List<int>(A);
            a.Sort();
            if (a[0] >= 0)
            {
                return 2 * a[0];
            }
            if (a[a.Count - 1] <= 0)
            {
                return -2 * a[a.Count - 1];
            }
            int mid = 0;
            int absMid = Math.Abs(a[mid]);
            for (int i = 0; i < a.Count; i++)
            {
                if (absMid > Math.Abs(a[i]))
                {
                    mid = i;
                    absMid = Math.Abs(a[mid]);
                }
            }
            int left = 0, right = 0;
            int result = 2 * absMid;
            if (mid > 0 && mid + 1 < a.Count)
            {
                if (Math.Abs(a[mid] + a[mid + 1]) > Math.Abs(a[mid] + a[mid - 1]))
                {
                    left = mid - 1;
                    right = mid;
                }
                else
                {
                    left = mid;
                    right = mid + 1;
                }
            }
            else
            {
                if (mid > 0 && Math.Abs(a[mid] + a[mid - 1]) < Math.Abs(a[mid] * 2))
                {
                    left = mid - 1;
                    right = mid;
                }
                else if (mid < a.Count - 1 && Math.Abs(a[mid] + a[mid + 1]) < Math.Abs(a[mid] * 2))
                {
                    left = mid;
                    right = mid + 1;
                }
                else
                {
                    left = mid;
                    right = mid;
                }
            }
            result = Math.Min(result, Math.Abs(a[left] + a[right]));
            while (left >= 0 || right < a.Count)
            {
                int? left1 = null;
                if (left - 1 >= 0)
                {
                    left1 = left - 1;
                }
                int? right1 = null;
                if (right + 1 < a.Count)
                {
                    right1 = right + 1;
                }
                if (left1.HasValue && right1.HasValue)
                {
                    if (Math.Abs(a[(int)left1] + a[right]) > Math.Abs(a[left] + a[(int)right1]))
                    {
                        right = (int)right1;
                    }
                    else
                    {
                        left = (int)left1;
                    }
                    result = Math.Min(result, Math.Abs(a[left] + a[right]));
                }
                else if (left1.HasValue)
                {
                    left = (int)left1;
                    result = Math.Min(result, Math.Abs(a[left] + a[right]));
                }
                else if (right1.HasValue)
                {
                    right = (int)right1;
                    result = Math.Min(result, Math.Abs(a[left] + a[right]));
                }
                else
                {
                    break;
                }
            }
            return result;
        }
        public static int solution2(int[] A)
        {
            List<int> a = new List<int>(A);
            a.Sort();
            int start = 0;
            int end = a.Count - 1;
            int res = Math.Min(Math.Abs(2 * a[start]), Math.Abs(2 * a[end]));
            bool isStartChange = false, isEndChange = false;
            while (start <= end)
            {
                if (isStartChange)
                {
                    res = Math.Min(Math.Abs(2 * a[start]), res);
                    isStartChange = false;
                }
                if (isEndChange)
                {
                    res = Math.Min(Math.Abs(2 * a[end]), res);
                    isEndChange = false;
                }
                res = Math.Min(Math.Abs(a[start] + a[end]), res);
                if (Math.Abs(a[start]) < Math.Abs(a[end]))
                {
                    end--;
                    isEndChange = true;
                }
                else
                {
                    start++;
                    isStartChange = true;
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 1, 4, -3 }));//1
            Console.WriteLine(solution(new int[] { -8, 4, 5, -10, 3 }));//3
            Console.WriteLine(solution(new int[] { -98, 99 }));//1
            Console.WriteLine(solution(new int[] { 8, 5, 3, 4, 6, 8 }));//6
            Console.WriteLine(solution(new int[] { 1, 2, 5, 8, -5, -1, 3, 8, -4, -23, 5, 6 }));//0
        }
    }
}
