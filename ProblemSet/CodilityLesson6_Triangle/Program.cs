using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson6_Triangle
{
    class Program
    {
        public static int solution(int[] A)
        {
            // write your code in Java SE 8
            List<int> a = A.OrderBy(x => x).ToList();
            for (int i = 0; i < a.Count - 2; i++)
            {
                if ((long)a[i] + a[i + 1] > a[i + 2])
                {
                    return 1;
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 10, 2, 5, 1, 8, 20 })); //1
            Console.WriteLine(solution(new int[] { 10, 50, 5, 1 }));//0
        }
    }
}
