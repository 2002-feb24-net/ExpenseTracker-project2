using ExpenseService.DataAccess.Model;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.Model
{
    public class BudgetsTests
    {
        private MockRepository mockRepository;



        public BudgetsTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Budgets CreateBudgets()
        {
            return new Budgets();
        }

        [Fact]
        public void TestMethod1()
        {

            var budgets = this.CreateBudgets();
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
