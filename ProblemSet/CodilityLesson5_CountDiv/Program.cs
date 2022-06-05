using System;

namespace CodilityLesson5_CountDiv
{
    class Program
    {
        public static int solution(int A, int B, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            A += (A % K == 0 ? 0 : K - (A % K));
            B -= (B % K == 0 ? 0 : (B % K));
            return (B>=A?((B - A) / K + 1):0);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution(6,11,2));
        }
    }
}
