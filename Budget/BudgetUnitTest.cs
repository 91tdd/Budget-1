using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Budget
{
    [TestClass]
    public class BudgetUnitTest
    {
        private readonly IRepository<Budget> _repository = Substitute.For<IRepository<Budget>>();
        private  BudgetCalculation _calculator;

        [TestInitialize]
        private void Init()
        {
            _calculator = new BudgetCalculation(_repository);
            _repository.GetBudgets().Returns(new List<Budget>
            {
                new Budget
                {
                    YearMonth = "201801",
                    Amount = 0
                }
            });
        }

        [TestMethod]
        public void NoBudget()
        {
            
            var range = new InputRange("2018-01-01", "2018-01-31");
            var actual = _calculator.GetValidBudgetBy(range);
            Assert.AreEqual(0, actual);
        }
    }
}
