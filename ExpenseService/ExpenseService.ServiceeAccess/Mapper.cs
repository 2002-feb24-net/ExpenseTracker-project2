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
    }
}
