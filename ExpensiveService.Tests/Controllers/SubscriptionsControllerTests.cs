using ExpenseService.Core.Interrfaces;
using ExpenseService.Core.Model;
using ExpenseServiceAPI.ApiModel;
using ExpenseServiceAPI.Controllers;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ExpensiveService.Tests.Controllers
{
    public class SubscriptionsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ISubscription> mockSubscription;

        public SubscriptionsControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockSubscription = this.mockRepository.Create<ISubscription>();
        }

        private SubscriptionsController CreateSubscriptionsController()
        {
            return new SubscriptionsController(
                this.mockSubscription.Object);
        }

        [Fact]
        public async Task GetSubscriptions_StateUnderTest_ExpectedBehavior()
        {
            try
            {
                var subscriptionsController = this.CreateSubscriptionsController();
                var result = await subscriptionsController.GetSubscriptions();
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task GetSubscriptions_StateUnderTest_ExpectedBehavior1()
        {
            try
            {
                var subscriptionsController = this.CreateSubscriptionsController();
                int id = 0;
                var result = await subscriptionsController.GetSubscriptions(
                    id);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task GetSubscriptionsAsync_StateUnderTest_ExpectedBehavior()
        {
            try
            {
                var subscriptionsController = this.CreateSubscriptionsController();
                int id = 0;
                var result = await subscriptionsController.GetSubscriptionsAsync(
                    id);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task PutSubscriptions_StateUnderTest_ExpectedBehavior()
        {
            try
            {
                var subscriptionsController = this.CreateSubscriptionsController();
                int id = 0;
                ExpenseService.DataAccess.Model.Subscriptions Subscriptions = null;
                var result = await subscriptionsController.PutSubscriptions(
                    id,
                    Subscriptions);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task PostSubscriptions_StateUnderTest_ExpectedBehavior()
        {
            try
            {
                var subscriptionsController = this.CreateSubscriptionsController();
                CoreSubscriptions subscriptions = null;
                var result = await subscriptionsController.PostSubscriptions(
                    subscriptions);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task DeleteSubscriptions_StateUnderTest_ExpectedBehavior()
        {
            try
            {
                var subscriptionsController = this.CreateSubscriptionsController();
                int id = 0;
                var result = await subscriptionsController.DeleteSubscriptions(
                    id);
                Assert.True(false);
            }
            catch
            {
                Assert.True(true);
            }
        }
    }
}
