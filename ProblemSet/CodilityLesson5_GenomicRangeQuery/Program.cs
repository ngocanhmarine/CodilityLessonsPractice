using System;
using System.Collections.Generic;

namespace CodilityLesson5_GenomicRangeQuery
{
    class Program
    {
        public static int[] solution1(string S, int[] P, int[] Q)
        {
            Dictionary<char, int> nuDict = new Dictionary<char, int>();
            nuDict.Add('A', 1);
            nuDict.Add('C', 2);
            nuDict.Add('G', 3);
            nuDict.Add('T', 4);
            for (int i = 0; i < P.Length; i++)
            {
                int? min = null;
                for (int j = P[i]; j <= Q[i]; j++)
                {

                    if (min == null || min > nuDict[S[j]])
                    {
                        min = nuDict[S[j]];
                    }
                }
                P[i] = (int)min;
            }
            return P;
        }
        public static int[] solution2(string S, int[] P, int[] Q)
        {
            for (int i = 0; i < P.Length; i++)
            {
                if (S.IndexOf('A', P[i], Q[i] - P[i] + 1) != -1)
                {
                    P[i] = 1;
                }
                else if (S.IndexOf('C', P[i], Q[i] - P[i] + 1) != -1)
                {
                    P[i] = 2;
                }
                else if (S.IndexOf('G', P[i], Q[i] - P[i] + 1) != -1)
                {
                    P[i] = 3;
                }
                else if (S.IndexOf('T', P[i], Q[i] - P[i] + 1) != -1)
                {
                    P[i] = 4;
                }
            }
            return P;
        }
        public static int[] solution3(string S, int[] P, int[] Q)
        {
            int[] A = new int[S.Length + 1];
            int[] C = new int[S.Length + 1];
            int[] G = new int[S.Length + 1];
            int[] R = new int[P.Length];
            int As = 0, Cs = 0, Gs = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == 'A')
                {
                    As++;
                }
                else if (S[i] == 'C')
                {
                    Cs++;
                }
                else if (S[i] == 'G')
                {
                    Gs++;
                }
                A[i + 1] = As;
                C[i + 1] = Cs;
                G[i + 1] = Gs;
            }
            for (int i = 0; i < P.Length; i++)
            {
                int r = 4;
                if (G[Q[i] + 1] - G[P[i]] > 0)
                {
                    r = 3;
                }
                if (C[Q[i] + 1] - C[P[i]] > 0)
                {
                    r = 2;
                }
                if (A[Q[i] + 1] - A[P[i]] > 0)
                {
                    r = 1;
                }
                R[i] = r;
            }
            return R;
        }
        static void Main(string[] args)
        {
            string S = (new string('G', 10000)) + (new string('C', 20000));


            int[] P = new int[] { 10002, 5, 4 };
            int[] Q = new int[] { 24004, 8, 16 };
            //var p = solution3("A", new int[] { 0 }, new int[] { 0 });
            //var p = solution3("CAGCCTA", new int[] { 2, 5, 0 }, new int[] { 4, 5, 6 });
            var p = solution3("AC", new int[] { 0, 0, 1 }, new int[] { 0, 1, 1 });
            foreach (var item in p)
            {
                Console.Write(item + ",");
            }
        }
    }
}
