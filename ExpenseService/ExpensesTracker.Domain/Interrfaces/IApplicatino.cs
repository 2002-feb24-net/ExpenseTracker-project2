using ExpenseService.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Interrfaces
{
    public interface IApplicatino
    {
        Task<IEnumerable<LoanApplication>> GetLoanApplicationAsync(int? userId = null);
        Task<LoanApplication> GetBudgetByIdAsync(int id);
        Task<bool> BudgetExsistsAsync(int id);
        Task<LoanApplication> AddBudgetAsync(LoanApplication LoanApplication);
        Task<bool> RemoveBudgetAsync(int id);
        public EntityState Changed(LoanApplication LoanApplication);

        Task SaveAsync();
    }
}
