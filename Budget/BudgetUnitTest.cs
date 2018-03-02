using System;
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
        public void Init()
        {
            _calculator = new BudgetCalculation(_repository);
        }

        [TestMethod]
        public void NoBudget()
        {
            
            var range = new InputRange("2017-01-01", "2017-01-31");
            _repository.GetBudgets().Returns(new List<Budget>
            {
                new Budget
                {
                    YearMonth = "201712",
                    Amount = 0
                }
            });
            var actual = _calculator.GetValidBudgetBy(range);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void HaveBudget()
        {
            
            var range = new InputRange("2018-01-01", "2018-01-31");
            _repository.GetBudgets().Returns(new List<Budget>
            {
                new Budget
                {
                    YearMonth = "201801",
                    Amount = 31000
                }
            });
            var actual = _calculator.GetValidBudgetBy(range);
            Assert.AreEqual(31000, actual);
        }

        [TestMethod]
        public void HaveBudget_20180201_20180315()
        {

            var range = new InputRange("2018-02-01", "2018-03-15");
            _repository.GetBudgets().Returns(new List<Budget>
            {
                new Budget
                {
                    YearMonth = "201802",
                    Amount = 28
                },
                new Budget
                {
                    YearMonth = "201803",
                    Amount = 3100
                }
            });
            var actual = _calculator.GetValidBudgetBy(range);
            Assert.AreEqual(1528, actual);
        }
        [TestMethod]
        public void HaveBudget_20180201_20180415()
        {

            var range = new InputRange("2018-02-01", "2018-04-15");
            _repository.GetBudgets().Returns(new List<Budget>
            {
                new Budget
                {
                    YearMonth = "201802",
                    Amount = 28
                },
                new Budget
                {
                    YearMonth = "201803",
                    Amount = 3100
                },new Budget
                {
                    YearMonth = "201804",
                    Amount = 30000
                }
            });
            var actual = _calculator.GetValidBudgetBy(range);
            Assert.AreEqual(18128, actual);
        }

        [TestMethod]
        public void HaveBudget_20180210_20180215()
        {

            var range = new InputRange("2018-02-10", "2018-2-15");
            _repository.GetBudgets().Returns(new List<Budget>
            {
                new Budget
                {
                    YearMonth = "201802",
                    Amount = 28
                },
            });
            var actual = _calculator.GetValidBudgetBy(range);
            Assert.AreEqual(6, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidRange()
        {

            var range = new InputRange("2018-02-15", "2018-2-10");
            _repository.GetBudgets().Returns(new List<Budget>
            {
                new Budget
                {
                    YearMonth = "201802",
                    Amount = 28
                },
            });
            var actual = _calculator.GetValidBudgetBy(range);
        }
    }
}
