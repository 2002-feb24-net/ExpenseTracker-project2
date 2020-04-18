using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseService.Domain.Model
{
    public class Loan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal MonthlyRate { get; set; }
        public decimal InterestRate { get; set; }
        public decimal RetainingCost { get; set; }
        public decimal AccumulatedCost { get; set; }
    }
}
