using System;
using System.Collections.Generic;

namespace CodilityLesson7_StoneWall
{
    class Program
    {
        public static int solution1(int[] H)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            // do not count a block if H[i]==0
            int count = 0;
            for (int i = 0; i < H.Length; i++)
            {
                if (H[i] != 0)
                {
                    count++;
                    int val = H[i];
                    for (int j = i; j < H.Length; j++)
                    {
                        if (H[j] >= val)
                        {
                            H[j] -= val;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }
            return count;
        }
        public static int solution2(int[] H)
        {
            //counted as block with height=0 if H[i]==0
            int count = 0;
            Stack<int> passes = new Stack<int>();
            for (int i = 0; i < H.Length; i++)
            {
                if (passes.Count > 0 && passes.Peek() >= H[i])
                {
                    while (passes.Count > 0 && passes.Peek() > H[i])
                    {
                        passes.Pop();
                    }
                    if (passes.Count > 0)
                    {
                        if (passes.Peek() == H[i])
                        {
                            continue;
                        }
                    }
                }
                if (H[i] != 0)
                {
                    count++;
                    passes.Push(H[i]);
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution2(new int[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 }));//7
            Console.WriteLine(solution2(new int[] { 8, 8, 5, 7, 9, 8, 7, 5, 8 }));//6
            Console.WriteLine(solution2(new int[] { 1, 2, 3, 4, 3 }));//4
            Console.WriteLine(solution2(new int[] { 8, 8, 5 }));//2
            Console.WriteLine(solution2(new int[] { 8, }));//1
            Console.WriteLine(solution2(new int[] { 8, }));//1
            Console.WriteLine(solution2(new int[] { 8, 8 }));//1
            Console.WriteLine(solution2(new int[] { 8, 8, 8, 8, 8 }));//1
            Console.WriteLine(solution2(new int[] { 1000000000 }));//1
            Console.WriteLine(solution2(new int[] { 1000000000, 2 }));//2
            Console.WriteLine(solution2(new int[] { 2, 1000000000, 2 }));//2
            Console.WriteLine(solution2(new int[] { 2, 1000000000, 2, 1000000000 }));//3
            Console.WriteLine(solution2(new int[] { 2, 1000000000, 2, 1000000000, 1000000000 }));//3
            Console.WriteLine(solution1(new int[] { 12, 0, 65, 234 }));//4
        }
    }
}
