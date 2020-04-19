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
    public class LoanRepository : ILoanRepository
    {
        private readonly RevatureDatabaseContext _context;

        public LoanRepository(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Domain.Model.Loan> AddLoanAsync(Domain.Model.Loan Loan)
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

        public EntityState Changed(Domain.Model.Loan Loan)
        {
            return _context.Entry(Loan).State = EntityState.Modified;
        }

        public async Task<Domain.Model.Loan> GetLoanByIdAsync(int id)
        {
            var Loan = await _context.Loan.FindAsync(id);

            return Mapper.MapLoan(Loan);
        }

        public async Task<IEnumerable<Domain.Model.Loan>> GetLoanAsync(int? userId = null)
        {
            IQueryable<Models.Loan> query = _context.Loan
                .Include(u => u.User);

            if (userId != null)
            {
                query = query.Where(u => u.User.Id == userId);
            }

            List<Models.Loan> Loan = await query
                .ToListAsync();

            return Loan.Select(Mapper.MapLoan);
        }

        public async Task<bool> RemoveLoanAsync(int id)
        {
            Models.Loan Loan = await _context.Loan.FindAsync(id);

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
    }
}
