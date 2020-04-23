using ExpenseService.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseService.Core.Interrfaces
{
    public interface IBudgetRepository
    {
        Task<IEnumerable<CoreBudgets>> GetBudgetsAsync(int? userId = null);
        Task<CoreBudgets> GetBudgetByIdAsync(int id);
        Task<bool> BudgetExsistsAsync(int id);
        Task<CoreBudgets> AddBudgetAsync(CoreBudgets Budgets);
        Task<bool> RemoveBudgetAsync(int id);
        public EntityState Changed(CoreBudgets Budgets);

        Task SaveAsync();
    }
}
