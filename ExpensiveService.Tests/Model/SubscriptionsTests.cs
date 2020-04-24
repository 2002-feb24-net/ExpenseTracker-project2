using ExpenseService.DataAccess.Model;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.Model
{
    public class SubscriptionsTests
    {
        private MockRepository mockRepository;



        public SubscriptionsTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Subscriptions CreateSubscriptions()
        {
            return new Subscriptions();
        }

        [Fact]
        public void TestMethod1()
        {
            var subscriptions = this.CreateSubscriptions();
            Assert.True(subscriptions != null);
            this.mockRepository.VerifyAll();
        }
    }
}
