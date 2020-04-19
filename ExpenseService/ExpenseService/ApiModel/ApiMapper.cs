using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseServiceAPI.ApiModel
{
    public class ApiMapper
    {
        public static Bills MapBillsApi(ExpenseService.Domain.Model.Bills bills)
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
                CurrentUser = MapUserApi(bills.CurrentUser)
                
            };
        }

        public static Budgets MapBudgets(ExpenseService.Domain.Model.Budgets budgets)
        {
            return new Budgets
            {
                Id = budgets.Id,
                ActualCost = budgets.ActualCost,
                EstimatedCost = budgets.EstimatedCost,
                UserId = budgets.UserId,
                User = MapUserApi(budgets.CurrentUser)
            };
        }

        public static Users MapUserApi(ExpenseService.Domain.Model.Users users)
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

        
    }
}
