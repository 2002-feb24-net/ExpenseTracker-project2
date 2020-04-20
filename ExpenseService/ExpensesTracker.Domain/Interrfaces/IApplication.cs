using ExpenseService.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Interrfaces
{
    public interface IApplication
    {
        Task<IEnumerable<LoanApplication>> GetLoanApplicationAsync(int? userId = null);
        Task<LoanApplication> GetLoanApplicationByIdAsync(int id);
        Task<bool> LoanApplicationExsistsAsync(int id);
        Task<LoanApplication> AddLoanApplicationAsync(LoanApplication LoanApplication);
        Task<bool> RemoveLoanApplicationAsync(int id);
        public EntityState Changed(LoanApplication LoanApplication);

        Task SaveAsync();
    }
}
