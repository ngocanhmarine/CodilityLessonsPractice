using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson3_PermMissingElem
{
    class Program
    {
        public static int solution(int[] A)
        {

            if (A.Length == 0)
            {
                return 1;
            }
            List<int> a = A.OrderBy(x => x).ToList();
            if (a.Last() == a.Count())
            {
                return a.Last() + 1;
            }
            int n = a.Count() / 2;
            int b = 0, t = a.Count() - 1;
            while (b != t)
            {
                if (a[n] == n + 1)
                {
                    b = n + 1;
                }
                else
                {
                    t = n;
                }
                n = (b + t) / 2;
            }
            return b + 1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 2, 3, 1, 6, 5 }));
        }
    }
}
