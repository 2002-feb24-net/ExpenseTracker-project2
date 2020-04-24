using System;
using ExpenseService.Core.Interrfaces;
using ExpenseService.DataAccess.Repository;
using ExpenseServiceAPI.Controllers;
using Moq;
using Xunit;
using FluentAssertions;
using ExpenseService.Core.Model;
using ExpenseService.DataAccess;

namespace ExpensiveService.Tests
{
    public class BudgetsControllerTest
    {
        [Fact]
        public void AddBills()
        {
            var listOfBudgets = new CoreBudgets();
            Mock<IBudgetRepository> mockBudgetRepository = new Mock<IBudgetRepository>();
            mockBudgetRepository.Setup(x => x.AddBudgetAsync(listOfBudgets)).Verifiable();
            var billController = new BudgetsController(mockBudgetRepository.Object);
            billController.Should().NotBeNull();
        }
        [Fact]
        public void GetBudgets()
        {
            var listOfBills = new CoreBudgets();
            var a = Mapper.MapBudgets(listOfBills);
            Mock<IBillsRepository> mockBillRepository = new Mock<IBillsRepository>();
            mockBillRepository.Setup(x => x.GetBillsAsync(null)).Verifiable();
            var billController = new BillsController(mockBillRepository.Object);
            billController.Should().NotBeNull();
        }
    }
}
