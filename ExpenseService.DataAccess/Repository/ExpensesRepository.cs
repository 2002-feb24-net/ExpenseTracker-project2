using ExpenseService.Core.Interrfaces;
using ExpenseService.Core.Model;
using ExpenseService.DataAccess.Model;
using ExpenseService.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.DataAccess.Repository
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly RevatureDatabaseContext _context;

        public ExpensesRepository(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Core.Model.CoreUsers> AddUsersAsync(Core.Model.CoreUsers user)
        {
            var newUser = new Model.Users
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

        public async Task<Core.Model.CoreUsers> GetUserAsync(int id)
        {
            Model.Users users = await _context.Users.FirstAsync(u => u.Id == id);

            return MapUser(users);
        }

        public async Task<IEnumerable<Core.Model.CoreUsers>> GetUsersAsync()
        {
            List<Model.Users> users = await _context.Users.ToListAsync();
            return users.Select(MapUser);

        }

        public async Task<bool> RemoveUserAsync(int id)
        {
            Model.Users user = await _context.Users.FindAsync(id);

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

        public EntityState Changed(Core.Model.CoreUsers users)
        {
            return _context.Entry(users).State = EntityState.Modified;
        }



        private static Core.Model.CoreUsers MapUser(Model.Users users)
        {
            return users is null ? null : new Core.Model.CoreUsers
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

        public async Task<Model.Users> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void RemoveUsers(Model.Users users)
        {
            _context.Users.Remove(users);
        }
    }
}
