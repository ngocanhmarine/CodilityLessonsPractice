using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson6_MaxProductOfThree
{
    class Program
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> l = A.OrderByDescending(s => s).ToList();
            int r = l[0];
            if (r >= 0)
            {
                r = (l[l.Count - 1] * l[l.Count - 2] > l[1] * l[2]) ? (l[0] * l[l.Count - 1] * l[l.Count - 2]) : (l[0] * l[1] * l[2]);
            }
            else
            {
                r = l[0] * l[1] * l[2];
            }
            return r;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { -3, 1, 2, -2, 5, 6 })); //60
            Console.WriteLine(solution(new int[] { -2, -3, -5, -6, 0 })); //0
            Console.WriteLine(solution(new int[] { -1,-2,-3,-4,-5,-6 })); //-6
        }
    }
}
