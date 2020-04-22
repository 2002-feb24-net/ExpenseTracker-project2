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
    public class ApplicationRepository : IApplication
    {
        private readonly RevatureDatabaseContext _context;

        public ApplicationRepository(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Core.Model.CoreLoanApplication> AddLoanApplicationAsync(Core.Model.CoreLoanApplication LoanApplication)
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

        public EntityState Changed(Core.Model.CoreLoanApplication LoanApplication)
        {
            return _context.Entry(LoanApplication).State = EntityState.Modified;
        }

        public async Task<Core.Model.CoreLoanApplication> GetLoanApplicationByIdAsync(int id)
        {
            var LoanApplication = await _context.LoanApplication.FindAsync(id);

            return MapApplication(LoanApplication);
        }

        public async Task<IEnumerable<Core.Model.CoreLoanApplication>> GetLoanApplicationAsync(int? userId = null)
        {
            IQueryable<Model.LoanApplication> query = _context.LoanApplication
                .Include(u => u.User);

            if (userId != null)
            {
                query = query.Where(u => u.User.Id == userId);
            }

            List<Model.LoanApplication> LoanApplication = await query
                .ToListAsync();

            return LoanApplication.Select(Mapper.MapApplication);
        }

        public async Task<bool> RemoveLoanApplicationAsync(int id)
        {
            Model.LoanApplication LoanApplication = await _context.LoanApplication.FindAsync(id);

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

        private static Core.Model.CoreLoanApplication MapApplication(Model.LoanApplication application)
        {
            return application is null ? null : new Core.Model.CoreLoanApplication
            {
                Id = application.Id,
                ApprovalDenialComformation = application.ApprovalDenialComformation,
                CreditScore = application.CreditScore,
                EstIncome = application.EstIncome,
                LoanAmount = application.LoanAmount,
                Ssn = application.Ssn,
                UserId = application.UserId,
                //Users = MapUsers(application.User)
            };
        }
    }
}
