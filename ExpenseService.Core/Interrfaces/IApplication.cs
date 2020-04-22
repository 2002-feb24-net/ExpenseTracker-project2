using ExpenseService.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Core.Interrfaces
{
    public interface IApplication
    {
        Task<IEnumerable<CoreLoanApplication>> GetLoanApplicationAsync(int? userId = null);
        Task<CoreLoanApplication> GetLoanApplicationByIdAsync(int id);
        Task<bool> LoanApplicationExsistsAsync(int id);
        Task<CoreLoanApplication> AddLoanApplicationAsync(CoreLoanApplication LoanApplication);
        Task<bool> RemoveLoanApplicationAsync(int id);
        public EntityState Changed(CoreLoanApplication LoanApplication);

        Task SaveAsync();
    }
}
