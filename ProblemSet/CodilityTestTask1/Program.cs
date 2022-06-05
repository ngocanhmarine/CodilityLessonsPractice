using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityTestTask1
{
    class Program
    {
        public static string solution(string message, int K)
        {
            string result = "";
            List<string> sep = message.Split(" ").ToList();
            int totalLength = result.Length;
            for (int i = 0; i < sep.Count(); i++)
            {
                totalLength += (i == 0 ? 0 : 1) + sep[i].Length;
                if (totalLength > K)
                {
                    return result;
                }
                else
                {
                    result += (string.IsNullOrEmpty(result) ? "" : " ") + sep[i];
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution("Codility We test coders", 14));
        }
    }
}
