﻿using ExpenseService.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Core.Interrfaces
{
    public interface IBillsRepository
    {
        Task<IEnumerable<Bills>> GetBillsAsync(int? userId = null);
        Task<Bills> GetBillByIdAsync(int id);
        Task<bool> BillExsistsAsync(int id);
        Task<Bills> AddBillAsync(Bills bills);
        Task<bool> RemoveBillAsync(int id);
        public EntityState Changed(Bills bills);

        Task SaveAsync();
    }
}
