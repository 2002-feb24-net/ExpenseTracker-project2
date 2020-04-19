using ExpenseService.Domain.Interrfaces;
using ExpenseService.Domain.Model;
using ExpenseService.ServiceeAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.ServiceeAccess.Repository
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly RevatureDatabaseContext _context;

        public BudgetRepository(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Domain.Model.Budgets> AddBudgetAsync(Domain.Model.Budgets Budgets)
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

        public EntityState Changed(Domain.Model.Budgets Budgets)
        {
            return _context.Entry(Budgets).State = EntityState.Modified;
        }

        public async Task<Domain.Model.Budgets> GetBudgetByIdAsync(int id)
        {
            var Budget = await _context.Budgets.FindAsync(id);

            return Mapper.MapBudgets(Budget);
        }

        public async Task<IEnumerable<Domain.Model.Budgets>> GetBudgetsAsync(int? userId = null)
        {
            IQueryable<Models.Budgets> query = _context.Budgets
                .Include(u => u.User);

            if (userId != null)
            {
                query = query.Where(u => u.User.Id == userId);
            }

            List<Models.Budgets> Budgets = await query
                .ToListAsync();

            return Budgets.Select(Mapper.MapBudgets);
        }

        public async Task<bool> RemoveBudgetAsync(int id)
        {
            Models.Budgets Budgets = await _context.Budgets.FindAsync(id);

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
    }
}
