using ExpenseService.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Interrfaces
{
    public interface IBudgetRepository
    {
        Task<IEnumerable<Budgets>> GetBudgetsAsync(int? userId = null);
        Task<Budgets> GetBudgetByIdAsync(int id);
        Task<bool> BudgetExsistsAsync(int id);
        Task<Budgets> AddBudgetAsync(Budgets Budgets);
        Task<bool> RemoveBudgetAsync(int id);
        public EntityState Changed(Budgets Budgets);

        Task SaveAsync();
    }
}
