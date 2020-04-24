using ExpenseServiceAPI.ApiModel;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.ApiModel
{
    public class ApiBudgetsTests
    {
        private MockRepository mockRepository;



        public ApiBudgetsTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ApiBudgets CreateApiBudgets()
        {
            return new ApiBudgets();
        }

        [Fact]
        public void TestMethod1()
        {
            var apiBudgets = this.CreateApiBudgets();
            Assert.True(true);
        }
    }
}
