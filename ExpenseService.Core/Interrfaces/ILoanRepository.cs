using ExpenseService.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Core.Interrfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetLoanAsync(int? userId = null);
        Task<Loan> GetLoanByIdAsync(int id);
        Task<bool> LoanExsistsAsync(int id);
        Task<Loan> AddLoanAsync(Loan Loan);
        Task<bool> RemoveLoanAsync(int id);
        EntityState Changed(Loan Loan);

        Task SaveAsync();
    }
}
