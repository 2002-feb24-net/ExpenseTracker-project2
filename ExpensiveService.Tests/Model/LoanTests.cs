using ExpenseService.DataAccess.Model;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.Model
{
    public class LoanTests
    {
        private MockRepository mockRepository;



        public LoanTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Loan CreateLoan()
        {
            return new Loan();
        }

        [Fact]
        public void TestMethod1()
        {
            var loan = this.CreateLoan();
            Assert.True(loan != null);
            this.mockRepository.VerifyAll();
        }
    }
}
