using ExpenseServiceAPI.ApiModel;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.ApiModel
{
    public class ApiBillsTests
    {
        private MockRepository mockRepository;



        public ApiBillsTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ApiBills CreateApiBills()
        {
            return new ApiBills();
        }

        [Fact]
        public void TestMethod1()
        {
            var apiBills = new ApiBills();
            apiBills.Id = 1;
            apiBills.UserId = 2;
            apiBills.PurchaseName = "Mock";
            apiBills.Quantity = 2;
            apiBills.Cost = 3;
            apiBills.BillDate = new DateTime();
            apiBills.Location = "Mock Location";
            Assert.True(true);
        }
    }
}
