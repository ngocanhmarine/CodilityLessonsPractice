using System;
using System.Collections.Generic;

namespace CodilityLesson7_Brackets
{
    class Program
    {
        public static int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            Stack<char> s = new Stack<char>();
            List<char> starts = new List<char> { '(', '[', '{' };
            for (int i = 0; i < S.Length; i++)
            {
                if ((S[i] == ')' && s.Count > 0 && s.Pop() == '(')
                    || (S[i] == ']' && s.Count > 0 && s.Pop() == '[')
                    || (S[i] == '}' && s.Count > 0 && s.Pop() == '{')
                    )
                {
                    continue;
                }
                else if (starts.Contains(S[i]))
                {
                    s.Push(S[i]);
                }
                else return 0;
            }
            if (s.Count == 0)
            {
                return 1;
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution("{[()()]}")); //1
            Console.WriteLine(solution("([)()]")); //0
        }
    }
}
