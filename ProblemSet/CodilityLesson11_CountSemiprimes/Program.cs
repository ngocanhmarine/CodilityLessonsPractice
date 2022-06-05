using System;
using System.Collections.Generic;

namespace CodilityLesson11_CountSemiprimes
{
    class Program
    {
        public static int[] solution(int N, int[] P, int[] Q)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            DateTime d1 = DateTime.Now;
            int[] sieve = new int[N + 1];
            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(N)); i++)
            {
                int iter = i * i;
                while (iter <= N)
                {
                    if (sieve[iter - 1] == 0)
                    {
                        sieve[iter - 1] = i;
                    }
                    iter += i;
                }
            }
            DateTime d2 = DateTime.Now;
            List<int> primes = new List<int>();
            for (int i = 2; i <= N / 2; i++)
            {
                if (sieve[i - 1] == 0)
                {
                    primes.Add(i);
                }
            }
            DateTime d3 = DateTime.Now;
            List<int> semiPrimes = new List<int>();
            for (int i = 0; i < primes.Count; i++)
            {
                for (int j = i; j < primes.Count; j++)
                {
                    int prd = primes[i] * primes[j];
                    if (prd <= N)
                    {
                        semiPrimes.Add(prd);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            DateTime d4 = DateTime.Now;
            semiPrimes.Sort();
            DateTime d5 = DateTime.Now;
            int[] results = new int[P.Length];
            for (int i = 0; i < P.Length; i++)
            {
                int j = 0;
                while (j < semiPrimes.Count && semiPrimes[j] <= Q[i])
                {
                    if (semiPrimes[j] >= P[i])
                    {
                        results[i]++;
                    }
                    j++;
                }
            }

            DateTime d6 = DateTime.Now;
            Console.WriteLine("d2 - d1 = " + (d2 - d1).TotalMilliseconds);
            Console.WriteLine("d3 - d2 = " + (d3 - d2).TotalMilliseconds);
            Console.WriteLine("d4 - d3 = " + (d4 - d3).TotalMilliseconds);
            Console.WriteLine("d5 - d4 = " + (d5 - d4).TotalMilliseconds);
            Console.WriteLine("d6 - d5 = " + (d6 - d5).TotalMilliseconds);
            return results;
        }
        public static int[] solution2(int N, int[] P, int[] Q)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            DateTime d1 = DateTime.Now;
            int[] sieve = new int[N + 1];
            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(N)); i++)
            {
                int iter = i * i;
                while (iter <= N)
                {
                    if (sieve[iter - 1] == 0)
                    {
                        sieve[iter - 1] = i;
                    }
                    iter += i;
                }
            }
            DateTime d2 = DateTime.Now;
            List<int> primes = new List<int>();
            for (int i = 2; i <= N / 2; i++)
            {
                if (sieve[i - 1] == 0)
                {
                    primes.Add(i);
                }
            }
            DateTime d3 = DateTime.Now;
            int[] semiPrimes = new int[N + 1];

            for (int i = 0; i < primes.Count; i++)
            {
                for (int j = i; j < primes.Count; j++)
                {
                    int prd = primes[i] * primes[j];
                    if (prd <= N)
                    {
                        semiPrimes[prd] = 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            DateTime d4 = DateTime.Now;
            int[] semiCounts = new int[N + 1];
            for (int i = 4; i < N + 1; i++)
            {
                semiCounts[i] = semiCounts[i - 1];
                if (semiPrimes[i] == 1)
                {
                    semiCounts[i]++;
                }
            }

            DateTime d5 = DateTime.Now;

            int[] results = new int[P.Length];
            for (int i = 0; i < P.Length; i++)
            {
                results[i] = semiCounts[Q[i]] - semiCounts[P[i] - 1];
            }

            DateTime d6 = DateTime.Now;
            Console.WriteLine("d2 - d1 = " + (d2 - d1).TotalMilliseconds);
            Console.WriteLine("d3 - d2 = " + (d3 - d2).TotalMilliseconds);
            Console.WriteLine("d4 - d3 = " + (d4 - d3).TotalMilliseconds);
            Console.WriteLine("d5 - d4 = " + (d5 - d4).TotalMilliseconds);
            Console.WriteLine("d6 - d5 = " + (d6 - d5).TotalMilliseconds);
            return results;
        }
        static void Main(string[] args)
        {
            List<int[]> tests = new List<int[]>();
            tests.Add(solution2(26, new int[] { 1, 4, 16 }, new int[] { 26, 10, 20 })); // 10,4,0

            #region Test 2
            DateTime d1 = DateTime.Now;
            int[] P = new int[30000];
            int[] Q = new int[30000];
            for (int i = 0; i < P.Length; i++)
            {
                P[i] = new Random().Next(1, 50000);
                Q[i] = new Random().Next(P[i] + 1, 50000);
            }
            DateTime d2 = DateTime.Now;
            Console.WriteLine("Time to prepare test case: " + (d2 - d1).TotalMilliseconds);
            tests.Add(solution2(50000, P, Q));
            #endregion

            for (int i = 0; i < tests.Count; i++)
            {
                for (int j = 0; j < tests[i].Length; j++)
                {
                    Console.Write(tests[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
