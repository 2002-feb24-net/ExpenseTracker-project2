using ExpenseService.Domain.Interrfaces;
using ExpenseService.Domain.Model;
using ExpenseService.ServiceeAccess.Models;
using ExpenseService.ServiceeAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.ServiceeAccess.Repository
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly RevatureDatabaseContext _context;

        public async Task<Domain.Model.Users> AddUsersAsync(Domain.Model.Users user)
        {
            var newUser = new Models.Users
            {
                Id = user.Id,
                Name = user.Name,
                Address = user.Address,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return MapUser(newUser);

        }

        public async Task<Domain.Model.Users> GetUserAsync(int id)
        {
            Models.Users users = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return MapUser(users);
        }

        public async Task<IEnumerable<Domain.Model.Users>> GetUsersAsync()
        {
            List<Models.Users> users = await _context.Users.ToListAsync();
            return users.Select(MapUser);

        }

        public async Task<bool> RemoveUserAsync(int id)
        {
            Models.Users user = await _context.Users.FindAsync(id);

            if(user is null)
            {
                return false;
            }

            _context.Remove(user);

            int written = await _context.SaveChangesAsync();

            return written > 0;


        }

        public async Task<bool> UserExsistsAsync(int id)
        {
            return await _context.Users.AnyAsync(a => a.Id == id);
        }

        public EntityState Changed(Domain.Model.Users users)
        {
            return _context.Entry(users).State = EntityState.Modified;
        }



        private static Domain.Model.Users MapUser(Models.Users users)
        {
            return users is null ? null : new Domain.Model.Users
            {
                Id = users.Id,
                Name = users.Name,
                Password = users.Password,
                Address = users.Address,
                Email = users.Email,
                Membership = users.Membership,
                PhoneNumber = users.PhoneNumber
            };

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Models.Users> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void RemoveUsers(Models.Users users)
        {
            _context.Users.Remove(users);
        }
    }
}
