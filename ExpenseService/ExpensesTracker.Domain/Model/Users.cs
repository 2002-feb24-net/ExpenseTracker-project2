using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseService.Domain.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Membership { get; set; }
    }
}
