using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson12_CommonPrimeDivisors
{
    class Program
    {
        public static int solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int maxCase = Math.Max(A.Max(), B.Max());
            long[] sieve = new long[maxCase + 1];

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(maxCase)); i++)
            {
                int iter = i * i;
                while (iter <= maxCase)
                {
                    if (sieve[iter] == 0)
                    {
                        sieve[iter] = i;
                    }
                    iter += i;
                }
            }
            List<int> primes = new List<int>();
            for (int i = 2; i <= maxCase / 2; i++)
            {
                if (sieve[i] == 0)
                {
                    primes.Add(i);
                }
            }
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                long min = Math.Min(A[i], B[i]);
                HashSet<long> minPrimes = new HashSet<long>();
                while (sieve[min] != 0)
                {
                    minPrimes.Add(sieve[min]);
                    min /= sieve[min];
                }
                minPrimes.Add(min);
                long max = Math.Max(A[i], B[i]);
                HashSet<long> maxPrimes = new HashSet<long>();
                while (sieve[max] != 0)
                {
                    maxPrimes.Add(sieve[max]);
                    if (!minPrimes.Contains(sieve[max]))
                    {
                        break;
                    }
                    max /= sieve[max];
                }
                maxPrimes.Add(max);
                if (maxPrimes.Count != minPrimes.Count || !minPrimes.Contains(max)) continue;
                count++;
            }
            return count;
        }

        public static int solution2(int[] A, int[] B)
        {
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int a = A[i];
                int b = B[i];
                int gd;
                do
                {
                    gd = FindGreatestCommonDivisor(a, b);
                    if (gd > 1)
                    {
                        #region FindPrimes
                        int[] sieve = new int[gd + 1];
                        for (int j = 2; j <= Math.Ceiling(Math.Sqrt(gd)); j++)
                        {
                            int iter = j * j;
                            while (iter <= gd)
                            {
                                if (sieve[iter - 1] == 0)
                                {
                                    sieve[iter - 1] = j;
                                }
                                iter += j;
                            }
                        }
                        List<int> primes = new List<int>();
                        for (int j = 2; j <= gd; j++)
                        {
                            if (sieve[j - 1] == 0 && gd % j == 0)
                            {
                                primes.Add(j);
                            }
                        }
                        #endregion
                        for (int j = 0; j < primes.Count; j++)
                        {
                            while (a > 1 && a % primes[j] == 0)
                            {
                                a /= primes[j];
                            }
                            while (b > 1 && b % primes[j] == 0)
                            {
                                b /= primes[j];
                            }
                        }
                    }

                } while (gd != 1);
                if (a == b)
                {
                    count++;
                }
            }
            return count;
        }
        private static int FindGreatestCommonDivisor(int x, int y, int k = 1)
        {
            if (x == y)
            {
                return k * x;
            }
            else if (x % 2 == 0 && y % 2 == 0)
            {
                return FindGreatestCommonDivisor(x / 2, y / 2, k * 2);
            }
            else if (x % 2 == 0)
            {
                return FindGreatestCommonDivisor(x / 2, y, k);
            }
            else if (y % 2 == 0)
            {
                return FindGreatestCommonDivisor(x, y / 2, k);
            }
            else if (x > y)
            {
                return FindGreatestCommonDivisor(x - y, y, k);
            }
            else
            {
                return FindGreatestCommonDivisor(x, y - x, k);
            }
        }
        public static int solution3(int[] A, int[] B)
        {
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (HasAllPrimeFactorsOf(A[i], B[i]) && HasAllPrimeFactorsOf(B[i], A[i]))
                {
                    count++;
                }
            }
            return count;
        }
        private static bool HasAllPrimeFactorsOf(int A, int B)
        {
            if (B == 1) return true;
            int gcd = FindGreatestCommonDivisor(A, B);
            if (gcd == 1) return false;

            return HasAllPrimeFactorsOf(A, B / gcd);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution3(new int[] { 4 }, new int[] { 2 }));//1
            Console.WriteLine(solution3(new int[] { 8 }, new int[] { 6 }));//0
            Console.WriteLine(solution3(new int[] { 15, 10, 3 }, new int[] { 75, 30, 5 }));//1
            Console.WriteLine(solution3(new int[] { 2, 1, 2 }, new int[] { 1, 2, 2 }));//1
            Console.WriteLine(solution3(new int[] { (int)(Math.Pow(2, 5) * Math.Pow(13, 3)) }, new int[] { (int)(Math.Pow(2, 4) * Math.Pow(3, 3) * Math.Pow(13, 3)) }));//0
            int[] a = new int[100] { 4, 5, 1, 1, 5, 5, 9, 5, 8, 1, 7, 6, 1, 7, 1, 8, 4, 7, 1, 3, 7, 2, 8, 7, 7, 7, 4, 2, 4, 7, 9, 4, 9, 4, 2, 8, 7, 9, 6, 2, 2, 8, 8, 2, 4, 4, 3, 4, 2, 4, 2, 6, 2, 4, 3, 3, 5, 2, 7, 3, 9, 3, 5, 7, 6, 4, 1, 5, 5, 1, 5, 1, 7, 2, 9, 4, 9, 1, 1, 5, 1, 1, 5, 1, 7, 6, 3, 8, 1, 5, 3, 9, 4, 6, 4, 9, 6, 1, 7, 1 };
            int[] b = new int[100] { 3, 1, 9, 7, 2, 1, 2, 2, 3, 8, 9, 3, 2, 8, 8, 8, 8, 1, 3, 6, 7, 6, 8, 1, 3, 5, 5, 2, 9, 6, 9, 4, 4, 8, 2, 3, 2, 7, 7, 9, 4, 5, 2, 6, 3, 9, 4, 5, 4, 2, 6, 3, 2, 8, 2, 4, 5, 3, 6, 5, 5, 6, 6, 2, 2, 8, 6, 3, 3, 5, 1, 9, 6, 4, 7, 3, 5, 4, 7, 3, 1, 9, 2, 6, 6, 2, 5, 6, 1, 6, 1, 5, 8, 3, 8, 4, 5, 2, 9, 4 };
            Console.WriteLine(solution3(a, b));//22

            int[] q = new int[6000];
            int[] w = new int[6000];
            for (int i = 0; i < 6000; i++)
            {
                q[i] = new Random().Next(0, int.MaxValue);
                w[i] = new Random().Next(0, int.MaxValue);
            }
            Console.WriteLine(solution3(q, w));
        }
    }
}
