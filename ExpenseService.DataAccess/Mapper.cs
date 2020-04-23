

namespace ExpenseService.DataAccess
{
    public class Mapper
    {

        public static Core.Model.CoreUsers MapUsers(Model.Users users)
        {
            return new Core.Model.CoreUsers
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

        public static Model.Users MapUsers(Core.Model.CoreUsers users)
        {
            return new Model.Users
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

        public static Core.Model.CoreBills MapBills(Model.Bills bills)
        {
            return new Core.Model.CoreBills
            {
                Id = bills.Id,
                BillDate = bills.BillDate,
                Cost = bills.Cost,
                Location = bills.Location,
                PurchaseName = bills.PurchaseName,
                Quantity = bills.Quantity,
                UserId = bills.UserId,
                //CurrentUser = MapUsers(bills.User) 
            };
        }

        public static Model.Bills MapBills(Core.Model.CoreBills bills)
        {
            return new Model.Bills
            {
                Id = bills.Id,
                BillDate = bills.BillDate,
                Cost = bills.Cost,
                Location = bills.Location,
                PurchaseName = bills.PurchaseName,
                Quantity = bills.Quantity,
                UserId = bills.UserId,
                //User = MapUsers(bills.CurrentUser)
            };
        }

        public static Model.Budgets MapBudgets(Core.Model.CoreBudgets budgets)
        {
            return new Model.Budgets
            {
                Id = budgets.Id,
                ActualCost = budgets.ActualCost,
                EstimatedCost = budgets.EstimatedCost,
                UserId = budgets.UserId,
                //User = MapUsers(budgets.CurrentUser),
                Loan = budgets.Loan,
                Subscription = budgets.Subscription
            };
        }

        public static Core.Model.CoreBudgets MapBudgets(Model.Budgets budgets)
        {
            return new Core.Model.CoreBudgets
            {
                Id = budgets.Id,
                ActualCost = budgets.ActualCost,
                EstimatedCost = budgets.EstimatedCost,
                UserId = budgets.UserId,
                //CurrentUser = MapUsers(budgets.User),
                Loan = budgets.Loan,
                Subscription = budgets.Subscription
            };
        }

        public static Core.Model.CoreLoan MapLoan(Model.Loan loan)
        {
            return new Core.Model.CoreLoan
            {
                Id = loan.Id,
                AccumulatedCost = loan.AccumulatedCost,
                RetainingCost = loan.RetainingCost,
                InterestRate = loan.InterestRate,
                MonthlyRate = loan.MonthlyRate,
                UserId = loan.UserId,
                //CurrentUser = MapUsers(loan.User)

            };
        }

        public static Model.Loan MapLoan(Core.Model.CoreLoan loan)
        {
            return new Model.Loan
            {
                Id = loan.Id,
                AccumulatedCost = loan.AccumulatedCost,
                InterestRate = loan.InterestRate,
                MonthlyRate = loan.MonthlyRate,
                RetainingCost = loan.RetainingCost,
                UserId = loan.UserId,
                //User = MapUsers(loan.CurrentUser)
            };
        }

        public static Core.Model.CoreLoanApplication MapApplication(Model.LoanApplication application)
        {
            return new  Core.Model.CoreLoanApplication
            {
                Id = application.Id,
                ApprovalDenialComformation = application.ApprovalDenialComformation,
                CreditScore = application.CreditScore,
                EstIncome = application.EstIncome,
                LoanAmount = application.LoanAmount,
                Ssn = application.Ssn,
                UserId = application.UserId,
                //Users = MapUsers(application.User)
            };
        }

        public static Model.LoanApplication MapApplication(Core.Model.CoreLoanApplication application)
        {
            return new Model.LoanApplication
            {
                Id = application.Id,
                ApprovalDenialComformation = application.ApprovalDenialComformation,
                CreditScore = application.CreditScore,
                EstIncome = application.EstIncome,
                LoanAmount = application.LoanAmount,
                Ssn = application.Ssn,
                UserId = application.UserId,
                //User = MapUsers(application.Users)
            };
        }

        public static Core.Model.CoreSubscriptions MapSub(Model.Subscriptions subscriptions)
        {
            return new Core.Model.CoreSubscriptions
            {
                Id = subscriptions.Id,
                SubscriptionDate = subscriptions.SubscriptionDate,
                SubscriptionDueDate = subscriptions.SubscriptionDueDate,
                Company = subscriptions.Company,
                Notification = subscriptions.Notification,
                SubscriptionMonthCost = subscriptions.SubscriptionMonthCost,
                SubscriptionName = subscriptions.SubscriptionName,
                UserId = subscriptions.UserId
                //User = MapUsers(subscriptions.User)
            };
        }

        public static Model.Subscriptions MapSub(Core.Model.CoreSubscriptions subscriptions)
        {
            return new Model.Subscriptions
            {
                Id = subscriptions.Id,
                SubscriptionDate = subscriptions.SubscriptionDate,
                SubscriptionDueDate = subscriptions.SubscriptionDueDate,
                Company = subscriptions.Company,
                Notification = subscriptions.Notification,
                SubscriptionMonthCost = subscriptions.SubscriptionMonthCost,
                SubscriptionName = subscriptions.SubscriptionName,
                UserId = subscriptions.UserId
                //User = MapUsers(subscriptions.User)
            };
        }
    }
}
