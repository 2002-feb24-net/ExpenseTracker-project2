using System;
using System.Collections.Generic;

namespace ExpenseServiceAPI.Models
{
    public partial class Budgets
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal ActualCost { get; set; }
        public string Subscription { get; set; }
        public string Loan { get; set; }

        public virtual Users User { get; set; }
    }
}
