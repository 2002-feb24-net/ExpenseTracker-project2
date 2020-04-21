using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseServiceAPI.ApiModel
{
    public class Bills
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public Users CurrentUser { get; set; }

        public string PurchaseName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public DateTime BillDate { get; set; }
        public string Location { get; set; }
    }
}
