using System;
using System.Collections.Generic;

namespace CodilityLesson15_CountTriangles
{
    class Program
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> a = new List<int>(A);
            int res = 0;
            a.Sort();
            for (int x = 0; x < a.Count - 2; x++)
            {
                int z = x + 2;
                for (int y = x + 1; y < a.Count - 1; y++)
                {
                    while (z < a.Count)
                    {
                        if (a[x] + a[y] > a[z])
                        {
                            if (z == a.Count - 1) { res += z - y; break; }
                            z++;
                        }
                        else
                        {
                            if (z > y + 1) res += z - y - 1;
                            else z = y + 2;
                            break;
                        }
                    }
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 10, 2, 5, 1, 8, 12 }));
        }
    }
}
