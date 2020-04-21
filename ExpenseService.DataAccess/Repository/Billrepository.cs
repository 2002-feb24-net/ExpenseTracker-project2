using ExpenseService.Core.Interrfaces;
using ExpenseService.Core.Model;
using ExpenseService.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.DataAccess.Repository
{
    public class Billrepository : IBillsRepository
    {
        private readonly RevatureDatabaseContext _context;

        public Billrepository(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task <Core.Model.Bills> AddBillAsync(Core.Model.Bills bills)
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

        public EntityState Changed(Core.Model.Bills bills)
        {
            return _context.Entry(bills).State = EntityState.Modified;
        }

        public async Task<Core.Model.Bills> GetBillByIdAsync(int id)
        {
            var bill = await _context.Bills.FindAsync(id);

            return MapBills(bill);
        }

        public async Task<IEnumerable<Core.Model.Bills>> GetBillsAsync(int? userId = null)
        {
            IQueryable<Model.Bills> query = _context.Bills
                .Include(u => u.User);

            if(userId != null)
            {
                query = query.Where(u => u.User.Id == userId);
            }

            List<Model.Bills> bills = await query
                .ToListAsync();

            return bills.Select(Mapper.MapBills);
        }

        public async Task<bool> RemoveBillAsync(int id)
        {
            Model.Bills bills = await _context.Bills.FindAsync(id);

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

        private static Core.Model.Bills MapBills(Model.Bills bills)
        {
            return bills  is null ? null : new Core.Model.Bills
            {
                Id = bills.Id,
                BillDate = bills.BillDate,
                Cost = bills.Cost,
                Location = bills.Location,
                PurchaseName = bills.PurchaseName,
                Quantity = bills.Quantity,
                UserId = bills.UserId
            };

        }
    }
}
