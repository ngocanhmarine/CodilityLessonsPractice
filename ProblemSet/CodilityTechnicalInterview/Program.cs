using System;
using System.Collections.Generic;

namespace CodilityTechnicalInterview
{
    class Program
    {
        public static double[] getChange(double M, double P)
        {
            double[] r = new double[6] { 0, 0, 0, 0, 0, 0 };
            double don = M - P;
            r[5] = (int)Math.Floor(don / 1);
            don = Math.Round(don - r[5], 2);
            r[4] = (int)Math.Floor(don / .5);
            don = Math.Round(don - r[4] * .5, 2);
            r[3] = (int)Math.Floor(don / .25);
            don = Math.Round(don - r[3] * .25, 2);
            r[2] = (int)Math.Floor(don / .1);
            don = Math.Round(don - r[2] * .1, 2);
            r[1] = (int)Math.Floor(don / .05);
            don = Math.Round(don - r[1] * .05, 2);
            r[0] = (int)Math.Floor(don / .01);
            don = Math.Round(don - r[0] * .01, 2);

            string s = "[";
            foreach (var item in r)
            {
                s += item + ",";
            }
            s = s.Remove(s.Length - 1);
            s += "]";
            Console.WriteLine(s);
            return r;

        }
        static void Main(string[] args)
        {
            getChange(5, 0.99);
            getChange(3.14, 1.99);
            getChange(3, 0.01);
            getChange(4, 3.14);
            getChange(0.45, 0.34);

        }
    }
}
