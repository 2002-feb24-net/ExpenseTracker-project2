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
            var apiBills = this.CreateApiBills();
            Assert.True(true);
        }
    }
}
