using ExpenseServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.ServiceeAccess.Interrfaces
{
    //Interface for the Users repository
    interface IUserService
    {
        //Adds a user while using async
        Task AddUserAsync(Users user);

        //Gets all users while using async
        Task<IEnumerable<Users>> GetUsersASync();

    }
}
