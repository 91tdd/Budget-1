using System;
using System.Collections.Generic;

namespace Budget
{
    public class InputRange
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public InputRange(string from , string to)
        {
            From = DateTime.Parse(from);
            To = DateTime.Parse(to);

        }

        public int GetYearofFrom()
        {
            return From.Year;
        }
        public int GetMonthofFrom()
        {
            return From.Month;
        }

        public int GetDayofFrom()
        {
            return From.Day;
        }

        public int GetDayofTo()
        {
            return To.Day;
        }

        public Dictionary<string, DateTime> GetRangeMonths()
        {
            var months = new Dictionary<string, DateTime>();
            var a = From;
            while (To.Month - a.Month >= 0)
            {
                months.Add(a.ToString("yyyyMM"), a);
                a = a.AddMonths(1);
            }
            return months;
        }
    }
}