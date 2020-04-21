using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseServiceAPI.ApiModel
{
    public class Loan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal MonthlyRate { get; set; }
        public decimal InterestRate { get; set; }
        public decimal RetainingCost { get; set; }
        public decimal AccumulatedCost { get; set; }

        //public Users CurrentUser { get; set; }
    }
}
