﻿using System;
using System.Collections.Generic;

namespace ExpenseService.DataAccess.Model
{
    public partial class Bills
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PurchaseName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public DateTime BillDate { get; set; }
        public string Location { get; set; }

        public virtual Users User { get; set; }
    }
}
