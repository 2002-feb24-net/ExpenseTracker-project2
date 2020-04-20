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
    public class ApplicationRepository : IApplication
    {
        private readonly RevatureDatabaseContext _context;

        public ApplicationRepository(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Domain.Model.LoanApplication> AddLoanApplicationAsync(Domain.Model.LoanApplication LoanApplication)
        {
            var newLoanApplication = Mapper.MapApplication(LoanApplication);

            _context.LoanApplication.Add(newLoanApplication);
            await _context.SaveChangesAsync();

            return Mapper.MapApplication(newLoanApplication);
        }

        public async Task<bool> LoanApplicationExsistsAsync(int id)
        {
            return await _context.LoanApplication.AnyAsync(u => u.Id == id);
        }

        public EntityState Changed(Domain.Model.LoanApplication LoanApplication)
        {
            return _context.Entry(LoanApplication).State = EntityState.Modified;
        }

        public async Task<Domain.Model.LoanApplication> GetLoanApplicationByIdAsync(int id)
        {
            var LoanApplication = await _context.LoanApplication.FindAsync(id);

            return Mapper.MapApplication(LoanApplication);
        }

        public async Task<IEnumerable<Domain.Model.LoanApplication>> GetLoanApplicationAsync(int? userId = null)
        {
            IQueryable<Models.LoanApplication> query = _context.LoanApplication
                .Include(u => u.User);

            if (userId != null)
            {
                query = query.Where(u => u.User.Id == userId);
            }

            List<Models.LoanApplication> LoanApplication = await query
                .ToListAsync();

            return LoanApplication.Select(Mapper.MapApplication);
        }

        public async Task<bool> RemoveLoanApplicationAsync(int id)
        {
            Models.LoanApplication LoanApplication = await _context.LoanApplication.FindAsync(id);

            if (LoanApplication is null)
            {
                return false;
            }

            _context.Remove(LoanApplication);

            int written = await _context.SaveChangesAsync();

            return written > 0;
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
