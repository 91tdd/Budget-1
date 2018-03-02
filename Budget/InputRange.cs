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
    }
}