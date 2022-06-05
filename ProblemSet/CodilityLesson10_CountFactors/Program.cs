using System;

namespace CodilityLesson10_CountFactors
{
    class Program
    {
        public static int solution(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            int counter = 0;
            for (long i = 1; i * i <= N; i++)
            {
                if (N % i == 0 && i * i != N)
                {
                    counter += 2;
                }
                if (i * i == N)
                {
                    counter++;
                }
            }
            return counter;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(int.MaxValue));//8
        }
    }
}
