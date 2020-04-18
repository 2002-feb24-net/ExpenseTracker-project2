using ExpenseService.ServiceeAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.ServiceeAccess.Interrfaces
{
    public interface IBillsRepsitory
    {
        //Adds a bills while using async
        Task AddBillsAsync(Bills bills);

        //Gets all bills while using async
        Task<IEnumerable<Bills>> GetBillsAsync();

        //Delete bills
        Task DeleteBills(Bills bills);
    }
}
