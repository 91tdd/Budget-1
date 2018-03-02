using System.Collections.Generic;

namespace Budget
{
    public interface IRepository<T>
    {
        List<Budget> GetBudgets();
    }
}