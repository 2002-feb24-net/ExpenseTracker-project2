using ExpenseService.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseService.Core.Interrfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<CoreLoan>> GetLoanAsync(int? userId = null);
        Task<CoreLoan> GetLoanByIdAsync(int id);
        Task<bool> LoanExsistsAsync(int id);
        Task<CoreLoan> AddLoanAsync(CoreLoan Loan);
        Task<bool> RemoveLoanAsync(int id);
        EntityState Changed(CoreLoan Loan);

        Task SaveAsync();
    }
}
