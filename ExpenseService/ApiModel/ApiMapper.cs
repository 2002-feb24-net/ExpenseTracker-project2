using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseServiceAPI.ApiModel
{
    public class ApiMapper
    {
        public static Bills MapBillsApi(ExpenseService.Core.Model.Bills bills)
        {
            return new Bills
            {
                Id = bills.Id,
                BillDate = bills.BillDate,
                Cost = bills.Cost,
                Location = bills.Location,
                PurchaseName = bills.PurchaseName,
                Quantity = bills.Quantity,
                UserId = bills.UserId
                //CurrentUser = MapUserApi(bills.CurrentUser)
                
            };
        }

        public static Budgets MapBudgets(ExpenseService.Core.Model.Budgets budgets)
        {
            return new Budgets
            {
                Id = budgets.Id,
                ActualCost = budgets.ActualCost,
                EstimatedCost = budgets.EstimatedCost,
                UserId = budgets.UserId,
                //User = MapUserApi(budgets.CurrentUser)
            };
        }

        public static Users MapUserApi(ExpenseService.Core.Model.Users users)
        {
            return new Users
            {
                Id = users.Id,
                Address = users.Address,
                Email = users.Email,
                Membership = users.Membership,
                Name = users.Name,
                Password = users.Password,
                PhoneNumber = users.PhoneNumber
            };
        }

        public static Loan MapLoanApi(ExpenseService.Core.Model.Loan loan)
        {
            return new Loan
            {
                Id = loan.Id,
                UserId = loan.UserId,
                AccumulatedCost = loan.AccumulatedCost,
                InterestRate = loan.InterestRate,
                MonthlyRate = loan.MonthlyRate,
                RetainingCost = loan.RetainingCost,
                //CurrentUser = MapUserApi(loan.CurrentUser)
            };
        }

        public static Application MapApplication(ExpenseService.Core.Model.LoanApplication application)
        {
            return new Application
            {
                ApprovalDenialComformation = application.ApprovalDenialComformation,
                CreditScore = application.CreditScore,
                EstIncome = application.EstIncome,
                Id = application.Id,
                LoanAmount = application.LoanAmount,
                Ssn = application.Ssn,
                UserId = application.UserId,
                //Users = MapUserApi(application.Users)
            };
        }

        public static Sub MapSub(ExpenseService.Core.Model.Subscriptions sub)
        {
            return new Sub
            {
                Id = sub.Id,
                SubscriptionDate = sub.SubscriptionDate,
                SubscriptionDueDate = sub.SubscriptionDueDate,
                Company = sub.Company,
                Notification = sub.Notification,
                SubscriptionMonthCost = sub.SubscriptionMonthCost,
                SubscriptionName = sub.SubscriptionName,
                UserId = sub.UserId,
            };
        }
    }
}
