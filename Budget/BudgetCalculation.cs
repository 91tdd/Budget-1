using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Budget
{
    public class BudgetCalculation
    {
        private readonly IRepository<Budget> _repo;

        public BudgetCalculation(IRepository<Budget> repo)
        {
            _repo = repo;
        }

        public decimal GetValidBudgetBy(InputRange inputRange)
        {
            var budget = _repo.GetBudgets();
            
            var months = inputRange.GetRangeMonths();
            
            var result = 0;
            foreach (var month in months)
            {
                var totaldays = DateTime.DaysInMonth(month.Value.Year, month.Value.Month );
                var totalBudget = budget.Where(x => x.YearMonth == month.Key).Select(d => d.Amount).FirstOrDefault();

                if (string.Compare(month.Key, inputRange.From.ToString("yyyyMM")) == 0)
                {
                    result += (totaldays - inputRange.GetDayofFrom()+1) * totalBudget / totaldays;
                    continue;
                }

                if (string.Compare(month.Key, inputRange.To.ToString("yyyyMM")) == 0)
                {
                    result += totalBudget / totaldays * inputRange.GetDayofTo();
                    continue;
                }
                result += budget.Where(x => x.YearMonth == month.Key).Select(d => d.Amount).FirstOrDefault();

            }
            return result;
        }
    }
}