using ExpenseServiceAPI.ApiModel;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.ApiModel
{
    public class ApiSubTests
    {
        private MockRepository mockRepository;



        public ApiSubTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ApiSub CreateApiSub()
        {
            return new ApiSub();
        }

        [Fact]
        public void TestMethod1()
        {
            var apiSub = this.CreateApiSub();
            Assert.True(true);
        }
    }
}
