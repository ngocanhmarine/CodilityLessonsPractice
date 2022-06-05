using System;
using System.Collections.Generic;

namespace _1633A.Div7
{
    class Program
    {
        static void Solve(List<int> testCases)
        {
            foreach (int testCase in testCases)
            {
                int result;
                int modulo = testCase % 7;
                if (modulo == 0)
                {
                    result = testCase;
                }
                else if (testCase % 10 - modulo > 0)
                {
                    result = testCase - modulo;
                }
                else
                {
                    result = testCase + (7 - modulo);
                }
                Console.WriteLine(result);
            }
        }
        static void Main(string[] args)
        {
            int testCaseCount = Convert.ToInt32(Console.ReadLine());
            List<int> testCases = new List<int>();
            for (int i = 0; i < testCaseCount; i++)
            {
                testCases.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Solve(testCases);
        }
    }
}
