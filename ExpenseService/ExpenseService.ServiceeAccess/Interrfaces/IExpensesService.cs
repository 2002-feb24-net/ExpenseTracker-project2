using ExpenseService.ServiceeAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.ServiceeAccess.Interrfaces
{
    //Interface for the Users repository
    public interface IExpensesService
    {
        //Users
        //Adds a user while using async
        Task AddUserAsync(Users user);

        //Gets all users while using async
        Task<IEnumerable<Users>> GetUsersASync();

        //Delete user
        Task DeleteUseer(Users users);


        //Bills
        Task AddBillAsnyc(Bills bills);
        Task<IEnumerable<Bills>> GettBillsAsync();
        Task DeleteBillsAsync(Bills bills);

        //Budget
        Task AddBugetAsync(Budgets budgets);
        Task<IEnumerable<Budgets>> GetBudgetsAsync();
        Task DeleteBudgetAsync(Budgets budgets);

        //Loans
        Task AddLaonsAsync(Loan loan);
        Task<IEnumerable<Loan>> GetLoansAsync();
        Task DeleteLoan(Loan loan);

        //Loan Applicaton
        Task AddLoanApplication(LoanApplication application);
        Task<IEnumerable<LoanApplication>> GetApplications();
        Task DeleteApplication(LoanApplication application);
    }
}
