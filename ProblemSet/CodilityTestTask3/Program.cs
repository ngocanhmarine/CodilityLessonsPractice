using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityTestTask3
{
    class Program
    {
        public static int solution(int[] A)
        {
            int f = 0;
            //1:
            //List<double> a = new List<int>(A).ConvertAll(x => (double)x);

            //double p = a.Sum();
            //double e = p / 2;
            //while (p > e)
            //{
            //    int maxIndex = 0;
            //    for (int i = 0; i < a.Count; i++)
            //    {
            //        if (a[i] > a[maxIndex])
            //        {
            //            maxIndex = i;
            //        }
            //    }
            //    a[maxIndex] = a[maxIndex] / 2;
            //    p -= a[maxIndex];
            //    f++;
            //}

            //2:
            List<double> a = A.OrderByDescending(x => x).ToList().ConvertAll(x => (double)x);
            double p = a.Sum();
            double e = p / 2;
            int i = 0;
            int maxStep = 0;
            Dictionary<int, double> fixes = new Dictionary<int, double>();
            while (p > e)
            {
                a[i] = a[i] / 2;
                p -= a[i];
                f++;
                fixes[i] = a[i];
                if (i < a.Count - 1 && a[i + 1] > a[i])
                {
                    i++;
                    maxStep = i;
                }
                if (fixes.Where(k => a[k.Key] > a[i]).OrderByDescending(k => a[k.Key]).Select(x => (int?)x.Key).FirstOrDefault() is int x)
                {
                    i = x;
                }
                else
                {
                    i = maxStep;
                }
            }

            return f;
        }
        static void Main(string[] args)
        {
            var s = DateTime.Now;
            Console.WriteLine(solution(new int[] { 5, 19, 8, 1 }));
            Console.WriteLine(solution(new int[] { 10, 10 }));
            Console.WriteLine(solution(new int[] { 3, 0, 5 }));
            var e = DateTime.Now - s;
            Console.WriteLine($"Time consumed: {e.TotalMilliseconds}ms");
        }
    }
}
