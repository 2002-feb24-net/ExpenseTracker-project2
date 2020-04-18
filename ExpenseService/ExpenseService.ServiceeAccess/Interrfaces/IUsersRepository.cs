using ExpenseService.ServiceeAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.ServiceeAccess.Interrfaces
{
    //Interface for the Users repository
    public interface IUsersRepository
    {
        //Adds a user while using async
        Task AddUserAsync(Users user);

        //Gets all users while using async
        Task<IEnumerable<Users>> GetUsersASync();

        //Delete user
        Task DeleteUseer(Users users);

    }
}
