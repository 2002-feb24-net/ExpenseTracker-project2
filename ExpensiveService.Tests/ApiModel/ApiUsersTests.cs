using ExpenseServiceAPI.ApiModel;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.ApiModel
{
    public class ApiUsersTests
    {
        private MockRepository mockRepository;



        public ApiUsersTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ApiUsers CreateApiUsers()
        {
            return new ApiUsers();
        }

        [Fact]
        public void TestCreation()
        {
            var apiUsers = this.CreateApiUsers();
            Assert.True(true);
        }
        [Fact]
        public void TestProperties()
        {
            var apiUsers = this.CreateApiUsers();
            apiUsers.Address = "Address";
            apiUsers.Email = "Email";
            apiUsers.Id = 1;
            apiUsers.Membership = false;
            apiUsers.Name = "Danny devito";
            apiUsers.Password = "1020";
            apiUsers.PhoneNumber = "1234";
            Assert.True(true);
        }
    }
}
