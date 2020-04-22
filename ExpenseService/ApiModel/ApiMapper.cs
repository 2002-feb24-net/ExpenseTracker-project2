using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseServiceAPI.ApiModel
{
    public class ApiMapper
    {
        public static ApiBills MapBillsApi(ExpenseService.Core.Model.CoreBills bills)
        {
            return new ApiBills
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

        public static ApiBudgets MapBudgets(ExpenseService.Core.Model.CoreBudgets budgets)
        {
            return new ApiBudgets
            {
                Id = budgets.Id,
                ActualCost = budgets.ActualCost,
                EstimatedCost = budgets.EstimatedCost,
                UserId = budgets.UserId,
                //User = MapUserApi(budgets.CurrentUser)
            };
        }

        public static ApiUsers MapUserApi(ExpenseService.Core.Model.CoreUsers users)
        {
            return new ApiUsers
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

        public static ApiLoan MapLoanApi(ExpenseService.Core.Model.CoreLoan loan)
        {
            return new ApiLoan
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

        public static ApiApplication MapApplication(ExpenseService.Core.Model.CoreLoanApplication application)
        {
            return new ApiApplication
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

        public static ApiSub MapSub(ExpenseService.Core.Model.CoreSubscriptions sub)
        {
            return new ApiSub
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
