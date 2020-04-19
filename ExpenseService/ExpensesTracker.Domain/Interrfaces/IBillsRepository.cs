using ExpenseService.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Interrfaces
{
    interface IBillsRepository
    {
        Task<IEnumerable<Bills>> GetBillsAsync();
        Task<Bills> GetBillByIdAsync(int id);
        Task<bool> BillExsistsAsync(int id);
        Task<Users> AddBillAsync(Users users);
        Task<bool> RemoveBillAsync(int id);
        public EntityState Changed(Bills bills);

        Task SaveAsync();
    }
}
