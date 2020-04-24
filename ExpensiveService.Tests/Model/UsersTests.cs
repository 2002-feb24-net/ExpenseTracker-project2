using ExpenseService.DataAccess.Model;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.Model
{
    public class UsersTests
    {
        private MockRepository mockRepository;



        public UsersTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Users CreateUsers()
        {
            return new Users();
        }

        [Fact]
        public void TestMethod1()
        {
            var users = this.CreateUsers();
            Assert.True(users != null);
            this.mockRepository.VerifyAll();
        }
    }
}
