using System;

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

    }
}