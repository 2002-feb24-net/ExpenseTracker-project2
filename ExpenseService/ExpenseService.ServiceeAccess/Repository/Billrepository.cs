using ExpenseService.Domain.Interrfaces;
using ExpenseService.Domain.Model;
using ExpenseService.ServiceeAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.ServiceeAccess.Repository
{
    public class Billrepository : IBillsRepository
    {
        private readonly RevatureDatabaseContext _context;

        public Billrepository(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task <Domain.Model.Bills> AddBillAsync(Domain.Model.Bills bills)
        {
            var newBill = Mapper.MapBills(bills);

            _context.Bills.Add(newBill);
            await _context.SaveChangesAsync();

            return Mapper.MapBills(newBill);
        }

        public async Task<bool> BillExsistsAsync(int id)
        {
            return await _context.Bills.AnyAsync(u => u.Id == id);
        }

        public EntityState Changed(Domain.Model.Bills bills)
        {
            return _context.Entry(bills).State = EntityState.Modified;
        }

        public async Task<Domain.Model.Bills> GetBillByIdAsync(int id)
        {
            var bill = await _context.Bills.FindAsync(id);

            return Mapper.MapBills(bill);
        }

        public async Task<IEnumerable<Domain.Model.Bills>> GetBillsAsync(int? userId = null)
        {
            IQueryable<Models.Bills> query = _context.Bills
                .Include(u => u.User);

            if(userId != null)
            {
                query = query.Where(u => u.User.Id == userId);
            }

            List<Models.Bills> bills = await query
                .ToListAsync();

            return bills.Select(Mapper.MapBills);
        }

        public async Task<bool> RemoveBillAsync(int id)
        {
            Models.Bills bills = await _context.Bills.FindAsync(id);

            if (bills is null)
            {
                return false;
            }

            _context.Remove(bills);

            int written = await _context.SaveChangesAsync();

            return written > 0;
        }

        public Task SaveAsync()
        {
             return _context.SaveChangesAsync();
        }
    }
}
