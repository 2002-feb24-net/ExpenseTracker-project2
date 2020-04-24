using ExpenseService.DataAccess.Model;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.Model
{
    public class BillsTests
    {
        private MockRepository mockRepository;



        public BillsTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Bills CreateBills()
        {
            return new Bills();
        }

        [Fact]
        public void TestSetterGetters()
        {
            var bills = CreateBills();
            Assert.True(bills != null);
            this.mockRepository.VerifyAll();
        }
    }
}
