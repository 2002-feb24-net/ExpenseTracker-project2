using ExpenseService.Core.Model;
using ExpenseService.DataAccess;
using ExpenseService.DataAccess.Model;
using Moq;
using System;
using Xunit;

namespace ExpensiveService.Tests
{
    public class MapperTests
    {
        private MockRepository mockRepository;



        public MapperTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Mapper CreateMapper()
        {
            return new Mapper();
        }

        [Fact]
        public void MapUsers_StateUnderTest_Users()
        {
            var mapper = this.CreateMapper();
            Users users = new Users {
                Address = "Address",
                Email = "Email",
                Id = 1,
                Membership = false,
                Name = "Danny devito",
                Password = "1020",
                 PhoneNumber = "1234",
                };
            var result = Mapper.MapUsers(
                users);
            Assert.True(true);
        }

        [Fact]
        public void MapUsers_CoreUsers()
        {
            var mapper = this.CreateMapper();
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
            var result = Mapper.MapUsers(
                users);
            Assert.True(true);
        }

        [Fact]
        public void MapBill_Bills()
        {
            var mapper = this.CreateMapper();
            Bills bills = new Bills {
                BillDate = new DateTime(),
                Cost = 1,
                Id =1,
                Location="location",
                PurchaseName="purchase",
                Quantity=1,
                UserId=1,
                User=null
            };
            var result = Mapper.MapBills(
                bills);
            Assert.True(true);
        }

        [Fact]
        public void MapBills_CoreBills()
        {
            var mapper = this.CreateMapper();
            CoreBills bills = new CoreBills {
                BillDate = new DateTime(),
                Cost = 1,
                Id = 1,
                Location = "location",
                PurchaseName = "purchase",
                Quantity = 1,
                UserId = 1,
                    };
            var result = Mapper.MapBills(
                bills);
            Assert.True(true);
        }

        [Fact]
        public void MapBudgets_CoreBudgets()
        {
            var mapper = this.CreateMapper();
            CoreBudgets budgets = new CoreBudgets { 
                ActualCost=1,
                EstimatedCost=1,
                Id=1,
                Loan = null,
                Subscription = null,
                UserId = 1,
            };
            var result = Mapper.MapBudgets(
                budgets);
            Assert.True(true);
        }

        [Fact]
        public void MapBudgets_StateUnderTest_ExpectedBehavior1()
        {
            var mapper = this.CreateMapper();
            Budgets budgets = new Budgets
            {
                ActualCost = 1,
                EstimatedCost = 1,
                Id = 1,
                Loan = null,
                Subscription = null,
                UserId = 1,
            };
            var result = Mapper.MapBudgets(
                budgets);
            Assert.True(true);
        }

        [Fact]
        public void MapLoan_StateUnderTest_ExpectedBehavior()
        {
            var mapper = this.CreateMapper();
            Loan loan = new Loan { 
                AccumulatedCost=1,
                Id=1,
                InterestRate=1,
                MonthlyRate=1,
                RetainingCost=1,
                User=null,
                UserId=1
            };
            var result = Mapper.MapLoan(
                loan);
            Assert.True(true);
        }

        [Fact]
        public void MapLoan_StateUnderTest_ExpectedBehavior1()
        {
            var mapper = this.CreateMapper();
            CoreLoan loan = new CoreLoan
            {
                AccumulatedCost = 1,
                Id = 1,
                InterestRate = 1,
                MonthlyRate = 1,
                RetainingCost = 1,
                UserId = 1
            };
            var result = Mapper.MapLoan(
                loan);
            Assert.True(true);
        }

        [Fact]
        public void MapApplication_StateUnderTest_ExpectedBehavior()
        {
            var mapper = this.CreateMapper();
            LoanApplication application = new LoanApplication { 
                ApprovalDenialComformation = true,
                LoanAmount=1,
                CreditScore=1,
                EstIncome=1,
                Id=1,
                Ssn="1",
                User=null,
                UserId=1
            };
            var result = Mapper.MapApplication(
                application);
            Assert.True(true);
        }

        [Fact]
        public void MapApplication_StateUnderTest_ExpectedBehavior1()
        {
            var mapper = this.CreateMapper();
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
            var result = Mapper.MapApplication(
                application);
            Assert.True(true);
        }

        [Fact]
        public void MapSub_StateUnderTest_ExpectedBehavior()
        {
            var mapper = this.CreateMapper();
            Subscriptions subscriptions = new Subscriptions {
                Company = "company",
                Id = 1,
                Notification = true,
                SubscriptionDate = new DateTime(),
                SubscriptionDueDate = new DateTime(),
                SubscriptionMonthCost = 1,
                SubscriptionName = "name",
                User=null,
                UserId=1
            };
            var result = Mapper.MapSub(
                subscriptions);
            Assert.True(true);
        }

        [Fact]
        public void MapSub_StateUnderTest_ExpectedBehavior1()
        {
            var mapper = this.CreateMapper();
            CoreSubscriptions subscriptions = new CoreSubscriptions
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
            var result = Mapper.MapSub(
                subscriptions);
            Assert.True(true);
        }
    }
}
