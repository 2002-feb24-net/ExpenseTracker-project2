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
    public class Subscription : ISubscription
    {
        private readonly RevatureDatabaseContext _context;

        public Subscription(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Domain.Model.Subscriptions> AddSubscriptionsAsync(Domain.Model.Subscriptions Subscriptions)
        {
            var newSubscriptions = Mapper.MapSub(Subscriptions);

            _context.Subscriptions.Add(newSubscriptions);
            await _context.SaveChangesAsync();

            return Mapper.MapSub(newSubscriptions);
        }

        public async Task<bool> SubscriptionsExsistsAsync(int id)
        {
            return await _context.Subscriptions.AnyAsync(u => u.Id == id);
        }

        public EntityState Changed(Domain.Model.Subscriptions Subscriptions)
        {
            return _context.Entry(Subscriptions).State = EntityState.Modified;
        }

        public async Task<Domain.Model.Subscriptions> GetSubscriptionsByIdAsync(int id)
        {
            var Subscriptions = await _context.Subscriptions.FindAsync(id);

            return Mapper.MapSub(Subscriptions);
        }

        public async Task<IEnumerable<Domain.Model.Subscriptions>> GetSubscriptionssAsync(int? userId = null)
        {
            IQueryable<Models.Subscriptions> query = _context.Subscriptions
                .Include(u => u.User);

            if (userId != null)
            {
                query = query.Where(u => u.User.Id == userId);
            }

            var subs = await query
                .ToListAsync();

            return subs.Select(Mapper.MapSub);
        }

        public async Task<bool> RemoveSubscriptionsAsync(int id)
        {
            Models.Subscriptions Subscriptions = await _context.Subscriptions.FindAsync(id);

            if (Subscriptions is null)
            {
                return false;
            }

            _context.Remove(Subscriptions);

            int written = await _context.SaveChangesAsync();

            return written > 0;
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
