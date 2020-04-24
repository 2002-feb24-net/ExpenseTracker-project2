using ExpenseServiceAPI.ApiModel;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.ApiModel
{
    public class ApiApplicationTests
    {
        private MockRepository mockRepository;



        public ApiApplicationTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ApiApplication CreateApiApplication()
        {
            return new ApiApplication();
        }

        [Fact]
        public void TestMethod1()
        {
            var apiApplication = this.CreateApiApplication();
            Assert.True(true);
        }
    }
}
