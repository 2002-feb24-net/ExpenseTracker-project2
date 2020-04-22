using ExpenseService.Core.Interrfaces;
using ExpenseService.Core.Model;
using ExpenseService.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.DataAccess.Repository
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly RevatureDatabaseContext _context;

        public BudgetRepository(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Core.Model.CoreBudgets> AddBudgetAsync(Core.Model.CoreBudgets Budgets)
        {
            var newBudget = Mapper.MapBudgets(Budgets);

            _context.Budgets.Add(newBudget);
            await _context.SaveChangesAsync();

            return Mapper.MapBudgets(newBudget);
        }

        public async Task<bool> BudgetExsistsAsync(int id)
        {
            return await _context.Budgets.AnyAsync(u => u.Id == id);
        }

        public EntityState Changed(Core.Model.CoreBudgets Budgets)
        {
            return _context.Entry(Budgets).State = EntityState.Modified;
        }

        public async Task<Core.Model.CoreBudgets> GetBudgetByIdAsync(int id)
        {
            var Budget = await _context.Budgets.FindAsync(id);

            return MapBudgets(Budget);
        }

        public async Task<IEnumerable<Core.Model.CoreBudgets>> GetBudgetsAsync(int? userId = null)
        {
            IQueryable<Model.Budgets> query = _context.Budgets
                .Include(u => u.User);

            if (userId != null)
            {
                query = query.Where(u => u.User.Id == userId);
            }

            List<Model.Budgets> Budgets = await query
                .ToListAsync();

            return Budgets.Select(Mapper.MapBudgets);
        }

        public async Task<bool> RemoveBudgetAsync(int id)
        {
            Model.Budgets Budgets = await _context.Budgets.FindAsync(id);

            if (Budgets is null)
            {
                return false;
            }

            _context.Remove(Budgets);

            int written = await _context.SaveChangesAsync();

            return written > 0;
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        private static Core.Model.CoreBudgets MapBudgets(Model.Budgets budgets)
        {
            return budgets is null ? null : new Core.Model.CoreBudgets
            {
                Id = budgets.Id,
                ActualCost = budgets.ActualCost,
                EstimatedCost = budgets.EstimatedCost,
                UserId = budgets.UserId,
                Loan = budgets.Loan,
                Subscription = budgets.Subscription
            };
        }
    }
}
