using System;

namespace CodilityLesson3_FrogJmp
{
    class Program
    {
        public static int solution(int X, int Y, int D)
        {
            int z = (Y - X) % D;
            return (Y - X) / D + (z > 0 ? 1 : 0);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
