﻿using System;
using System.Collections.Generic;

namespace ExpenseService.DataAccess.Model
{
    public partial class Subscriptions
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
