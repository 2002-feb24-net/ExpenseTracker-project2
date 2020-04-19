using ExpenseService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Interrfaces
{
    public interface IExpensesRepository
    {
        Task<IEnumerable<Users>> GetUsersAsync();
        Task<Users> GetUserAsync(int id);
        Task<bool> UserExsistsAsync(int id);
        Task<Users> AddUsersAsync(Users users);
        Task<bool> RemoveUserAsync(int id);
    }
}
