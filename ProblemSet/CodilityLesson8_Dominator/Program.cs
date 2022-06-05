using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson8_Dominator
{
    class Program
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> a = A.OrderBy(x => x).ToList();
            int count = 0;
            int r = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == a[a.Count / 2])
                {
                    count++;
                    r = i;
                }
            }
            return (count > a.Count / 2) ? r : -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 3, 4, 3, 2, 3, -1, 3, 3 }));//0/2/4/6/7
            Console.WriteLine(solution(new int[] { 2, 1, 1, 3 }));//1/2
        }
    }
}
