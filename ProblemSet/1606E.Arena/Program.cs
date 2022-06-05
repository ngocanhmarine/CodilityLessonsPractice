using System;
using System.Globalization;

namespace _1606E.Arena
{
    class Program
    {
        public static string Format(DateTime date, DateTime current)
        {
            var timePassed = DateTime.Now - date;
            int timeAmount = 0;
            string datetimeUnit = string.Empty;
            if (timePassed.CompareTo(TimeSpan.FromMinutes(1))<0)
            {
                return "now";
            }
            else if (timePassed.CompareTo(TimeSpan.FromHours(1)) < 0)
            {
                timeAmount = timePassed.Minutes;
                datetimeUnit = "minute";
            }
            else if (timePassed.CompareTo(TimeSpan.FromDays(1)) < 0)
            {
                timeAmount = timePassed.Hours;
                datetimeUnit = "hour";
            }
            else if (timePassed.CompareTo(TimeSpan.FromDays(7)) < 0)
            {
                timeAmount = timePassed.Days;
                datetimeUnit = "day";
            }
            else
            {
                return current.ToString("yyyy-MM-dd HH:mm");
            }

            return String.Format("{0} {1}(s) ago", timeAmount, datetimeUnit);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Format(DateTime.Now.AddMinutes(-1), DateTime.Now));
            Console.WriteLine("Hello World!");
        }
    }
}
