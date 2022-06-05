using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson4_MaxCounters
{
    class Program
    {
        public static int[] solution(int N, int[] A)
        {
            //1
            int[] res = new int[N];
            int max = 0, lastupdate = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == N + 1)
                {
                    lastupdate = max;
                }
                else
                {
                    res[A[i] - 1] = (res[A[i] - 1] < lastupdate ? lastupdate + 1 : res[A[i] - 1] + 1);

                    if (max < res[A[i] - 1])
                    {
                        max = res[A[i] - 1];
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                if (res[i] < lastupdate)
                {
                    res[i] = lastupdate;
                }
            }
            return res;

            //2
            //List<int> res = new List<int>(A);
            //int max = 0;
            //int[] r = new int[N];
            //while (res.Count > 0)
            //{
            //    int nextMax = res.IndexOf(N + 1);
            //    if (nextMax == -1)
            //    {
            //        var temp = res.GroupBy(x => x).Select(x => new { a = x.Key, c = x.Count() });
            //        foreach (var item in temp)
            //        {
            //            r[item.a - 1] = item.c;
            //        }
            //        for (int i = 0; i < r.Length; i++)
            //        {
            //            r[i] += max;
            //        }
            //        break;
            //    }
            //    else
            //    {
            //        int increment = res.GetRange(0, nextMax).GroupBy(x => x).Select(x => x.Count()).OrderByDescending(x => x).FirstOrDefault();
            //        max += increment;
            //        res = res.GetRange(nextMax + 1, res.Count - nextMax - 1);
            //    }
            //}
            //return r;
        }
        static void Main(string[] args)
        {
            var x = solution(5, new int[] { 3, 4, 4, 6, 1, 4, 4 });
            foreach (var item in x)
            {
                Console.Write(item + ",");
            }
        }
    }
}
