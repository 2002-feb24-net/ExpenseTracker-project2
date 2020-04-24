using System;
using ExpenseService.Core.Interrfaces;
using ExpenseService.DataAccess.Repository;
using Moq;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using ExpenseService.DataAccess.Model;
using ExpenseService.DataAccess;
using ExpenseService.Core.Model;
using ExpenseServiceAPI.Controllers;

namespace ExpensiveService.Tests
{
    public class BillsControllerTest
    {
    [Fact]
        public void AddBills()
        {
            var listOfBills = new CoreBills();
            listOfBills = new CoreBills
            {
                Id = 1,
                UserId = 2,
                PurchaseName = "Mock",
                Quantity = 2,
                Cost = 3,
                BillDate = new DateTime(),
                Location = "Mock Location",
            };
            var a = Mapper.MapBills(listOfBills);
            Mock<IBillsRepository> mockBillRepository = new Mock<IBillsRepository>();
            mockBillRepository.Setup(x => x.AddBillAsync(listOfBills)).Verifiable();
            var billController = new BillsController(mockBillRepository.Object);
            billController.Should().NotBeNull();
        }
        [Fact]
        public void TestBills()
        {
            var listOfBills = new CoreBills();
            listOfBills = new CoreBills
            {
                Id = 1,
                UserId = 2,
                PurchaseName = "Mock",
                Quantity = 2,
                Cost = 3,
                BillDate = new DateTime(),
                Location = "Mock Location",
            };
            var bills = new Bills
            {
                Id = 1,
                UserId = 2,
                PurchaseName = "Mock",
                Quantity = 2,
                Cost = 3,
                BillDate = new DateTime(),
                Location = "Mock Location",
            };
            var a = Mapper.MapBills(listOfBills);
            Mock<IBillsRepository> mockBillRepository = new Mock<IBillsRepository>();
            mockBillRepository.Setup(x => x.GetBillsAsync(null)).Verifiable();
            var billController = new BillsController(mockBillRepository.Object);
            var bill = billController.GetBills();
            var bill2 = billController.GetUserBills(1);
            var bill3 = billController.PostBills(bills);
            var bill4 = billController.PutBills(1,bills);
            var bill5 = billController.DeleteBills(1);
            billController.Should().NotBeNull();
        }
    }
}
