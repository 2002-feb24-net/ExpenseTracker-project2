using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseServiceAPI.ApiModel
{
    public class Sub
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Company { get; set; }
        public string SubscriptionName { get; set; }
        public decimal SubscriptionMonthCost { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime SubscriptionDueDate { get; set; }
        public bool Notification { get; set; }

        public virtual Users User { get; set; }
    }
}
