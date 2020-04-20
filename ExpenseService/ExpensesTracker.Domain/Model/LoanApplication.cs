using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseService.Domain.Model
{
    public class LoanApplication
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Ssn { get; set; }
        public decimal CreditScore { get; set; }
        public decimal EstIncome { get; set; }
        public bool? ApprovalDenialComformation { get; set; }
        public decimal LoanAmount { get; set; }

        public Users Users { get; set; }
    }
}
