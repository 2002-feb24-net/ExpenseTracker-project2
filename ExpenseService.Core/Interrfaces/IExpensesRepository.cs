using ExpenseService.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseService.Core.Interrfaces
{
    public interface IExpensesRepository
    {
        Task<IEnumerable<CoreUsers>> GetUsersAsync();
        Task<CoreUsers> GetUserAsync(int id);
        Task<CoreUsers> GetUserAsy(int id, string phoneNumber);

        Task<bool> UserExsistsAsync(int id);
        Task<CoreUsers> AddUsersAsync(CoreUsers users);
        Task<bool> RemoveUserAsync(int id);
        public EntityState Changed(CoreUsers users);

        Task SaveAsync();
    }
}
