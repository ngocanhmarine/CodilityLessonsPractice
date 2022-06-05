using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static int solution(int[] A)
        {
            List<int> a = A.OrderBy(x => x).ToList();
            int? prev = null;
            for (int i = 0; i < a.Count(); i++)
            {
                if (prev == null)
                {
                    prev = a[i];
                }
                else if (prev == a[i])
                {
                    prev = null;
                }
                else
                {
                    return (int)prev;
                }
            }
            return prev!=null?(int)prev:0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 42 }));
        }
    }
}
