using System;
using System.Collections.Generic;

namespace CodilityLesson4_FrogRiverOne
{
    class Program
    {
        public static int solution(int X, int[] A)
        {
            int? r = null;
            HashSet<int> counter = new System.Collections.Generic.HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                counter.Add(A[i]);
                if (counter.Count == X)
                {
                    r = i;
                    break;
                }
            }
            return (r != null) ? (int)r : -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(5, new int[] { 1, 3, 1, 4, 2, 3, 5, 4 }));
        }
    }
}
