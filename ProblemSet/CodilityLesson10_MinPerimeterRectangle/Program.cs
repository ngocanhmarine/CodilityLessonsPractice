using System;

namespace CodilityLesson10_MinPerimeterRectangle
{
    class Program
    {
        public static int solution(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int min = (int)Math.Floor(Math.Sqrt(N));
            for (int i = min; i >= 1; i--)
            {
                if (N % i == 0)
                {
                    return 2 * i + 2 * (N / i);
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(solution(30));//22
            //Console.WriteLine(solution(1));//4
            //Console.WriteLine(solution(15486451));//30972904
            Console.WriteLine(solution(982451653));//
        }
    }
}
