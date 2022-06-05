using System;
using System.Collections.Generic;

namespace CodilityLesson12_ChocolatesByNumbers
{
    class Program
    {
        public static int solution(int N, int M)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            DateTime d1 = DateTime.Now;
            int[] n = new int[N];
            int count = 0;
            for (int i = 0; n[i] == 0; i = (i + M) % N)
            {
                n[i] = 1;
                count++;
            }
            DateTime d2 = DateTime.Now;
            Console.WriteLine($"time: {(d2 - d1).TotalMilliseconds}");
            return count;
        }
        public static int solution2(int N, int M)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int count = (int)Math.Ceiling(N / (double)M);
            HashSet<int> colK = new HashSet<int>() { 0 };
            int k = 0;
            if (N % M != 0) k = (M - (N % M)) % N;
            while (k != 0 & !colK.Contains(k))
            {
                colK.Add(k);
                count += (int)Math.Ceiling((N - k) / (double)M);
                if ((N - k) % M > 0) k = (M - ((N - k) % M)) % N;
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution2(10, 4));//5
            Console.WriteLine(solution2(24, 18));//4
            Console.WriteLine(solution2(12, 21));//4
            Console.WriteLine(solution2(10, 3));//10
            Console.WriteLine(solution2(123, 321));//41
            Console.WriteLine(solution2(1000000000, 1));//1000000000
            Console.WriteLine(solution2((int)(Math.Pow(3, 9) * Math.Pow(2, 14)), (int)(Math.Pow(2, 14) * Math.Pow(2, 14))));//19683
        }
    }
}
