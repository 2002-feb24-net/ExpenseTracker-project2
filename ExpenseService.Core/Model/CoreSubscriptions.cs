using System;

namespace ExpenseService.Core.Model
{
    public class CoreSubscriptions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Company { get; set; }
        public string SubscriptionName { get; set; }
        public decimal SubscriptionMonthCost { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime SubscriptionDueDate { get; set; }
        public bool Notification { get; set; }

        public CoreUsers User { get; set; }
    }
}
