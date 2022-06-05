using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson3_TapeEquilibrium
{
    class Program
    {
        public static int solution(int[] A)
        {
            List<int> a = new List<int>(A);
            int sum = a.Sum();
            int x = 0;
            int min = int.MaxValue;
            for (int i = 0; i < a.Count()-1; i++)
            {
                x += a[i];
                int y = Math.Abs(sum - 2 * x);
                if (y < min)
                {
                    min = y;
                }
            }
            return min;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 10,-10 }));
        }
    }
}
