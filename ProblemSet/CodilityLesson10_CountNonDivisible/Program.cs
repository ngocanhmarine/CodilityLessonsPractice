using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson11_CountNonDivisible
{
    class Program
    {
        public static int[] solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            DateTime d1 = DateTime.Now;
            List<int> a = A.OrderBy(x => x).ToList();
            List<int> sieve = new List<int>(new int[a[a.Count - 1] + 1]);
            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(a[a.Count - 1])); i++)
            {
                int iter = i * i;
                while (iter <= a[a.Count - 1])
                {
                    if (sieve[iter - 1] == 0) sieve[iter - 1] = i;
                    iter += i;
                }
            }
            DateTime d2 = DateTime.Now;
            int[] B = new int[A.Length];
            for (int i = 0; i < a.Count; i++)
            {
                int divisorCounter = 0;
                int iter = 0;
                while (iter < A.Length && a[iter] <= A[i])
                {
                    if (A[i] % a[iter] == 0) divisorCounter += 1;
                    iter++;
                }
                B[i] = A.Length - divisorCounter;
            }
            DateTime d3 = DateTime.Now;
            Console.WriteLine($"{(d2 - d1).TotalMilliseconds} ms");
            Console.WriteLine($"{(d3 - d2).TotalMilliseconds} ms");
            return B;
        }
        public static int[] solution2(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            DateTime d1 = DateTime.Now;
            List<int> a = A.OrderBy(x => x).ToList();
            DateTime d2 = DateTime.Now;
            int[] B = new int[A.Length];
            int[] C = new int[a[a.Count - 1] + 1];
            for (int i = 0; i < a.Count; i++)
            {
                int iter = a[i];
                while (iter <= a[a.Count - 1])
                {
                    C[iter]++;
                    iter += a[i];
                }
            }
            for (int i = 0; i < a.Count; i++)
            {
                B[i] = a.Count - C[A[i]];
            }
            DateTime d3 = DateTime.Now;
            Console.WriteLine($"{(d2 - d1).TotalMilliseconds} ms");
            Console.WriteLine($"{(d3 - d2).TotalMilliseconds} ms");
            return B;
        }

        public static int[] solution3(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            DateTime d1 = DateTime.Now;
            Dictionary<int, int> countInput = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                countInput[A[i]] = (countInput.ContainsKey(A[i])) ? countInput[A[i]]+1 : 1;
            }
            DateTime d2 = DateTime.Now;
            Dictionary<int, int> divisorCollection = new Dictionary<int, int>();
            foreach (KeyValuePair<int, int> item in countInput)
            {
                int countDivisor = 0;
                for (int j = 1; j <= Math.Sqrt(item.Key); j++)
                {
                    if (item.Key % j == 0)
                    {
                        if (countInput.ContainsKey(j))
                        {
                            countDivisor += countInput[j];
                        }
                        int opp = item.Key / j;
                        if (opp != j && countInput.ContainsKey(opp))
                        {
                            countDivisor += countInput[opp];
                        }
                    }
                }
                divisorCollection[item.Key] = countDivisor;
            }
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = A.Length - divisorCollection[A[i]];
            }
            DateTime d3 = DateTime.Now;
            Console.WriteLine($"{(d2 - d1).TotalMilliseconds} ms");
            Console.WriteLine($"{(d3 - d2).TotalMilliseconds} ms");
            return A;
        }
        static void Main(string[] args)
        {
            //var t1 = new int[] { 3, 1, 2, 3, 6 };//2,4,3,2,0

            //var t1 = new int[] { 2, 2, 3, 5, 6, 7, 30 };//5, 5, 6, 6, 3, 6, 1

            var t1 = new int[20000];
            for (int i = 0; i < t1.Length; i++)
            {
                t1[i] = new Random().Next(1, 40000);
            }

            var x = solution3(t1);
            foreach (var item in x)
            {
                Console.Write(item.ToString() + ",");
            }
        }
    }
}
