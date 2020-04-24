using ExpenseService.DataAccess.Model;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.Model
{
    public class RevatureDatabaseContextTests
    {
        private MockRepository mockRepository;



        public RevatureDatabaseContextTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private RevatureDatabaseContext CreateRevatureDatabaseContext()
        {
            return new RevatureDatabaseContext();
        }

        [Fact]
        public void TestMethod1()
        {
            var revatureDatabaseContext = this.CreateRevatureDatabaseContext();
            Assert.True(revatureDatabaseContext != null);
            this.mockRepository.VerifyAll();
        }
    }
}
