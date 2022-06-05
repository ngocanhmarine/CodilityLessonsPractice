using System;
using System.Collections.Generic;

namespace CodilityTestTask2
{
    class Program
    {
        static public int solution(int[] P, int[] S)
        {
            int result = 0;
            int t = 0;
            List<int> s = new List<int>(S);
            s.Sort((x, y) => x.CompareTo(y));
            foreach (int p in P)
            {
                t += p;
            }
            int c = 0, i = s.Count - 1;
            while (c < t)
            {
                result++;
                c += s[i];
                i--;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[] { 4,4,2,4 }, new int[] { 5,5,2,5}));
        }
    }
}
