using System;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }
    }
}