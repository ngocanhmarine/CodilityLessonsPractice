using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson1
{
    class Program
    {
        public static int Solution(int N)
        {
            string bin=Convert.ToString(N, 2);
            List<string> ss = bin.Split("1").ToList();
            ss.RemoveAt(ss.Count() - 1);
            return ss.Select(x => x.Length).Max();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Solution(32));
        }
    }
}
