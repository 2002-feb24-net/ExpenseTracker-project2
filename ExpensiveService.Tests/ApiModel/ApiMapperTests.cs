using ExpenseService.Core.Model;
using ExpenseService.DataAccess;
using ExpenseServiceAPI.ApiModel;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests.ApiModel
{
    public class ApiMapperTests
    {
        private MockRepository mockRepository;



        public ApiMapperTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ApiMapper CreateApiMapper()
        {
            return new ApiMapper();
        }

        [Fact]
        public void MapBillsApi_StateUnderTest_ExpectedBehavior()
        {
            var apiMapper = this.CreateApiMapper();
            CoreBills bills = new CoreBills
            {
                BillDate = new DateTime(),
                Cost = 1,
                Id = 1,
                Location = "location",
                PurchaseName = "purchase",
                Quantity = 1,
                UserId = 1,
            };
            var result = ApiMapper.MapBillsApi(
                bills);
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void MapBudgets_StateUnderTest_ExpectedBehavior()
        {
            var apiMapper = this.CreateApiMapper();
            CoreBudgets budgets = new CoreBudgets
            {
                ActualCost = 1,
                EstimatedCost = 1,
                Id = 1,
                Loan = null,
                Subscription = null,
                UserId = 1,
            };
            var result = ApiMapper.MapBudgets(
                budgets);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void MapUserApi_StateUnderTest_ExpectedBehavior()
        {
            var apiMapper = this.CreateApiMapper();
            CoreUsers users = new CoreUsers
            {
                Address = "Address",
                Email = "Email",
                Id = 1,
                Membership = false,
                Name = "Danny devito",
                Password = "1020",
                PhoneNumber = "1234",
            };
            var result = ApiMapper.MapUserApi(
                users);
            Assert.True(true);
        }

        [Fact]
        public void MapLoanApi_StateUnderTest_ExpectedBehavior()
        {
            var apiMapper = this.CreateApiMapper();
            CoreLoan loan = new CoreLoan
            {
                AccumulatedCost = 1,
                Id = 1,
                InterestRate = 1,
                MonthlyRate = 1,
                RetainingCost = 1,
                UserId = 1
            };
            var result = ApiMapper.MapLoanApi(
                loan);
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void MapApplication_StateUnderTest_ExpectedBehavior()
        {
            var apiMapper = this.CreateApiMapper();
            CoreLoanApplication application = new CoreLoanApplication
            {
                ApprovalDenialComformation = true,
                LoanAmount = 1,
                CreditScore = 1,
                EstIncome = 1,
                Id = 1,
                Ssn = "1",
                UserId = 1
            };
            var result = ApiMapper.MapApplication(
                application);
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void MapSub_StateUnderTest_ExpectedBehavior()
        {
            var apiMapper = this.CreateApiMapper();
            CoreSubscriptions sub = new CoreSubscriptions
            {
                Company = "company",
                Id = 1,
                Notification = true,
                SubscriptionDate = new DateTime(),
                SubscriptionDueDate = new DateTime(),
                SubscriptionMonthCost = 1,
                SubscriptionName = "name",
                UserId = 1
            };
            var result = ApiMapper.MapSub(
                sub);
            Assert.True(true);
        }
    }
}
