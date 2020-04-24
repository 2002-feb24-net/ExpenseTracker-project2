using ExpenseServiceAPI.ApiModel;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.ApiModel
{
    public class ApiLoanTests
    {
        private MockRepository mockRepository;



        public ApiLoanTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ApiLoan CreateApiLoan()
        {
            return new ApiLoan();
        }

        [Fact]
        public void TestMethod1()
        {
            var apiLoan = this.CreateApiLoan();
            Assert.True(true);
        }
    }
}
