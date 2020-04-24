using ExpenseService.DataAccess.Model;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.Model
{
    public class LoanApplicationTests
    {
        private MockRepository mockRepository;



        public LoanApplicationTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private LoanApplication CreateLoanApplication()
        {
            return new LoanApplication();
        }

        [Fact]
        public void TestMethod1()
        {
            var loanApplication = this.CreateLoanApplication();
            Assert.True(loanApplication != null);
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
