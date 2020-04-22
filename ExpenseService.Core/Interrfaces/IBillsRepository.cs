using ExpenseService.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Core.Interrfaces
{
    public interface IBillsRepository
    {
        Task<IEnumerable<CoreBills>> GetBillsAsync(int? userId = null);
        Task<CoreBills> GetBillByIdAsync(int id);
        Task<bool> BillExsistsAsync(int id);
        Task<CoreBills> AddBillAsync(CoreBills bills);
        Task<bool> RemoveBillAsync(int id);
        public EntityState Changed(CoreBills bills);

        Task SaveAsync();
    }
}
