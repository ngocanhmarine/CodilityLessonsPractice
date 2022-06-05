using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityLesson10_Flags
{
    class Program
    {
        public static int solution(int[] A)
        {
            List<int> peakIndices = new List<int>();
            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    peakIndices.Add(i);
                }
            }
            for (int i = peakIndices.Count; i > 0; i--)
            {
                List<int> temp = new List<int>() { peakIndices[0] };
                for (int j = 1; j < peakIndices.Count; j++)
                {
                    if (peakIndices[j] - temp.Last() >= i)
                    {
                        temp.Add(peakIndices[j]);
                        if (temp.Count >= i)
                        {
                            break;
                        }
                    }
                }
                if (temp.Count >= i)
                {
                    return i;
                }

            }
            return 0;
        }
        public static int solution2(int[] A)
        {
            List<int> peakIndices = new List<int>();
            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    peakIndices.Add(i);
                }
            }
            if (peakIndices.Count <= 1)
            {
                return peakIndices.Count;
            }
            int maxFlags = (int)Math.Ceiling(Math.Sqrt(peakIndices.Last() - peakIndices.First()));
            for (int i = maxFlags; i > 1; i--)
            {
                int start = 0;
                int end = peakIndices.Count - 1;
                int startPosition = peakIndices[start];
                int endPosition = peakIndices[end];
                int flagCount = 2;
                while (start < end)
                {
                    start++;
                    end--;
                    if (peakIndices[start] - startPosition >= i && peakIndices[start] + i <= endPosition)
                    {
                        flagCount++;
                        startPosition = peakIndices[start];
                    }
                    if (endPosition - peakIndices[end] >= i && peakIndices[end] - i >= startPosition)
                    {
                        flagCount++;
                        endPosition = peakIndices[end];
                    }
                    if (flagCount >= i)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(solution2(new int[] { 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 }));//3
            Console.WriteLine(solution2(new int[] { 1, 3, 2 }));//1
            Console.WriteLine(solution2(new int[] { 0, 0, 0, 0, 0, 1, 0, 1, 0, 1 }));//2
        }
    }
}
