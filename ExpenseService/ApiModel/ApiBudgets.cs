using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseServiceAPI.ApiModel
{
    public class ApiBudgets
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal ActualCost { get; set; }
        public string Subscription { get; set; }
        public string Loan { get; set; }

        public ApiUsers User { get; set; }
    }
}
