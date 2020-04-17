using System;
using System.Collections.Generic;

namespace ExpenseServiceAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Bills = new HashSet<Bills>();
            Budgets = new HashSet<Budgets>();
            Loan = new HashSet<Loan>();
            LoanApplication = new HashSet<LoanApplication>();
            Subscriptions = new HashSet<Subscriptions>();
        }

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Membership { get; set; }

        public virtual ICollection<Bills> Bills { get; set; }
        public virtual ICollection<Budgets> Budgets { get; set; }
        public virtual ICollection<Loan> Loan { get; set; }
        public virtual ICollection<LoanApplication> LoanApplication { get; set; }
        public virtual ICollection<Subscriptions> Subscriptions { get; set; }
    }
}
