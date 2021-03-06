﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseService.Core.Model
{
    public class CoreBudgets
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        //public Users CurrentUser { get; set; }

        public decimal EstimatedCost { get; set; }
        public decimal ActualCost { get; set; }
        public string Subscription { get; set; }
        public string Loan { get; set; }
    }
}
