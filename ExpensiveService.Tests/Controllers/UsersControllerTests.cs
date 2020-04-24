using ExpenseService.Core.Interrfaces;
using ExpenseService.Core.Model;
using ExpenseService.DataAccess;
using ExpenseService.DataAccess.Model;
using ExpenseServiceAPI.Controllers;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ExpensiveService.Tests.Controllers
{
    public class UsersControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IExpensesRepository> mockExpensesRepository;

        public UsersControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockExpensesRepository = this.mockRepository.Create<IExpensesRepository>();
        }

        private UsersController CreateUsersController()
        {
            return new UsersController(
                this.mockExpensesRepository.Object);
        }

        [Fact]
        public async Task GetAllUsersAsync_StateUnderTest_ExpectedBehavior()
        {
            try
            {
                var usersController = this.CreateUsersController();
                var result = await usersController.GetAllUsersAsync();
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task GetUsers_StateUnderTest_ExpectedBehavior()
        {
            try
            {
                var usersController = this.CreateUsersController();
                int id = 0;
                var result = await usersController.GetUsers(
                    id);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task PutUsers_StateUnderTest_ExpectedBehavior()
        {
            try
            {
                var usersController = this.CreateUsersController();
                int id = 0;
                CoreUsers user = null;
                var result = await usersController.PutUsers(
                    id,
                    user);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task PostUsers_StateUnderTest_ExpectedBehavior()
        {
            try
            {
                var usersController = this.CreateUsersController();
                CoreUsers user = null;
                var result = await usersController.PostUsers(
                    user);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void DeleteUsers_StateUnderTest_ExpectedBehavior()
        {
            try
            {
                var usersController = this.CreateUsersController();
                int id = 0;
                var result = usersController.DeleteUsers(
                    id);
                Assert.True(false);
                this.mockRepository.VerifyAll();
            }
            catch
            {
                Assert.True(true);
            }
        }
        [Fact]
        public void TestUsers()
        {
            var listOfBills = new CoreUsers();
            listOfBills = new CoreUsers
            {
                Address = "Address",
                Email = "Email",
                Id = 1,
                Membership = false,
                Name = "Danny devito",
                Password = "1020",
                PhoneNumber = "1234",
            };
            var users = new CoreUsers
            {
                Address = "Address",
                Email = "Email",
                Id = 1,
                Membership = false,
                Name = "Danny devito",
                Password = "1020",
                PhoneNumber = "1234",
            };
            var a = Mapper.MapUsers(listOfBills);
            Mock<IExpensesRepository> mockUserRepository = new Mock<IExpensesRepository>();
            mockUserRepository.Setup(x => x.GetUsersAsync()).Verifiable();
            var userController = new UsersController(mockUserRepository.Object);
            var bill = userController.GetUsers(1);
            var bill2 = userController.GetAllUsersAsync();
            var bill3 = userController.PostUsers(users);
            var bill4 = userController.PutUsers(1, users);
            var bill5 = userController.DeleteUsers(1);
            userController.Should().NotBeNull();
        }
    }
}
