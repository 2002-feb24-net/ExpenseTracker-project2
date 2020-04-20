using ExpenseService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseService.ServiceeAccess
{
    public static class Mapper
    {
        public static Users MapUsers(Models.Users users)
        {
            return new Users
            {
                Id = users.Id,
                Address = users.Address,
                Email = users.Email,
                Name = users.Name,
                Membership = users.Membership,
                Password = users.Password,
                PhoneNumber = users.PhoneNumber
            };
        }

        public static Models.Users MapUsers(Users users)
        {
            return new Models.Users
            {
                Id = users.Id,
                Address = users.Address,
                Email = users.Email,
                Name = users.Name,
                Membership = users.Membership,
                Password = users.Password,
                PhoneNumber = users.PhoneNumber
            };
        }

        public static Bills MapBills(Models.Bills bills)
        {
            return new Bills
            {
                Id = bills.Id,
                BillDate = bills.BillDate,
                Cost = bills.Cost,
                Location = bills.Location,
                PurchaseName = bills.PurchaseName,
                Quantity = bills.Quantity,
                UserId = bills.UserId,
                CurrentUser = MapUsers(bills.User)
            };
        }

        public static Models.Bills MapBills(Bills bills)
        {
            return new Models.Bills
            {
                Id = bills.Id,
                BillDate = bills.BillDate,
                Cost = bills.Cost,
                Location = bills.Location,
                PurchaseName = bills.PurchaseName,
                Quantity = bills.Quantity,
                UserId = bills.UserId,
                User = MapUsers(bills.CurrentUser)
            };
        }

        public static Models.Budgets MapBudgets(Budgets budgets)
        {
            return new Models.Budgets
            {
                Id = budgets.Id,
                ActualCost = budgets.ActualCost,
                EstimatedCost = budgets.EstimatedCost,
                UserId = budgets.UserId,
                User = MapUsers(budgets.CurrentUser),
                Loan = budgets.Loan,
                Subscription = budgets.Subscription
            };
        }
        
        public static Budgets MapBudgets(Models.Budgets budgets)
        {
            return new Budgets
            {
                Id = budgets.Id,
                ActualCost = budgets.ActualCost,
                EstimatedCost = budgets.EstimatedCost,
                UserId = budgets.UserId,
                CurrentUser = MapUsers(budgets.User),
                Loan = budgets.Loan,
                Subscription = budgets.Subscription
            };
        }

        public static Loan MapLoan(Models.Loan loan)
        {
            return new Loan
            {
                Id = loan.Id,
                AccumulatedCost = loan.AccumulatedCost,
                RetainingCost = loan.RetainingCost,
                InterestRate = loan.InterestRate,
                MonthlyRate = loan.MonthlyRate,
                UserId = loan.UserId,
                CurrentUser = MapUsers(loan.User)

            };
        }

        public static Models.Loan MapLoan(Loan loan)
        {
            return new Models.Loan
            {
                Id = loan.Id,
                AccumulatedCost = loan.AccumulatedCost,
                InterestRate = loan.InterestRate,
                MonthlyRate = loan.MonthlyRate,
                RetainingCost = loan.RetainingCost,
                UserId = loan.UserId,
                User = MapUsers(loan.CurrentUser)
            };
        }

        public static LoanApplication MapApplication(Models.LoanApplication application)
        {
            return new LoanApplication
            {
                Id = application.Id,
                ApprovalDenialComformation = application.ApprovalDenialComformation,
                CreditScore = application.CreditScore,
                EstIncome = application.EstIncome,
                LoanAmount = application.LoanAmount,
                Ssn = application.Ssn,
                UserId = application.UserId,
                Users = MapUsers(application.User)
            };
        }

        public static Models.LoanApplication MapApplication(LoanApplication application)
        {
            return new Models.LoanApplication
            {
                Id = application.Id,
                ApprovalDenialComformation = application.ApprovalDenialComformation,
                CreditScore = application.CreditScore,
                EstIncome = application.EstIncome,
                LoanAmount = application.LoanAmount,
                Ssn = application.Ssn,
                UserId = application.UserId,
                User = MapUsers(application.Users)
            };
        }
    }
}
