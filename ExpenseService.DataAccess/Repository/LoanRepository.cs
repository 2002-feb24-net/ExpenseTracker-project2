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
    public class LoanRepository : ILoanRepository
    {
        private readonly RevatureDatabaseContext _context;

        public LoanRepository(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Core.Model.Loan> AddLoanAsync(Core.Model.Loan Loan)
        {
            var newLoan = Mapper.MapLoan(Loan);

            _context.Loan.Add(newLoan);
            await _context.SaveChangesAsync();

            return Mapper.MapLoan(newLoan);
        }

        public async Task<bool> LoanExsistsAsync(int id)
        {
            return await _context.Loan.AnyAsync(u => u.Id == id);
        }

        public EntityState Changed(Core.Model.Loan Loan)
        {
            return _context.Entry(Loan).State = EntityState.Modified;
        }

        public async Task<Core.Model.Loan> GetLoanByIdAsync(int id)
        {
            var Loan = await _context.Loan.FirstOrDefaultAsync(a => a.Id == id);

            return MapLoan(Loan);
        }

        public async Task<IEnumerable<Core.Model.Loan>> GetLoanAsync(int? userId = null)
        {
            IQueryable<Model.Loan> query = _context.Loan
                .Include(u => u.User);

            if (userId != null)
            {
                query = query.Where(u => u.User.Id == userId);
            }

            List<Model.Loan> Loan = await query
                .ToListAsync();

            return Loan.Select(Mapper.MapLoan);
        }

        public async Task<bool> RemoveLoanAsync(int id)
        {
            Model.Loan Loan = await _context.Loan.FindAsync(id);

            if (Loan is null)
            {
                return false;
            }

            _context.Remove(Loan);

            int written = await _context.SaveChangesAsync();

            return written > 0;
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        private static Core.Model.Loan MapLoan(Model.Loan loan)
        {
            return loan is null ? null : new Core.Model.Loan
            {
                Id = loan.Id,
                AccumulatedCost = loan.AccumulatedCost,
                RetainingCost = loan.RetainingCost,
                InterestRate = loan.InterestRate,
                MonthlyRate = loan.MonthlyRate,
                UserId = loan.UserId,
                //CurrentUser = MapUsers(loan.User)

            };
        }
    }
}
