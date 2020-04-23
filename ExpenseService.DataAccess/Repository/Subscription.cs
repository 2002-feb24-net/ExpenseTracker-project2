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
    public class Subscription : ISubscription
    {
        private readonly RevatureDatabaseContext _context;

        public Subscription(RevatureDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Core.Model.CoreSubscriptions> AddSubscriptionsAsync(Core.Model.CoreSubscriptions Subscriptions)
        {
            var newUser = new Model.Subscriptions
            {
                Id = Subscriptions.Id,
                SubscriptionDueDate = Subscriptions.SubscriptionDueDate,
                SubscriptionDate = Subscriptions.SubscriptionDate,
                Company = Subscriptions.Company,
                Notification = Subscriptions.Notification,
                SubscriptionMonthCost = Subscriptions.SubscriptionMonthCost,
                SubscriptionName = Subscriptions.SubscriptionName,
                UserId = Subscriptions.UserId
            };
            _context.Subscriptions.Add(newUser);
            await _context.SaveChangesAsync();
            return MapSub(newUser);
        }

        public async Task<bool> SubscriptionsExsistsAsync(int id)
        {
            return await _context.Subscriptions.AnyAsync(u => u.Id == id);
        }

        public EntityState Changed(Core.Model.CoreSubscriptions Subscriptions)
        {
            return _context.Entry(Subscriptions).State = EntityState.Modified;
        }

        public async Task<Core.Model.CoreSubscriptions> GetSubscriptionsByIdAsync(int id)
        {
            var Subscriptions = await _context.Subscriptions.FindAsync(id);

            return MapSub(Subscriptions);
        }

        public async Task<IEnumerable<Core.Model.CoreSubscriptions>> GetSubscriptionssAsync(int? userId = null)
        {
            IQueryable<Model.Subscriptions> query = _context.Subscriptions.Include(u => u.User);

            if (userId != null)
            {
                query = query.Where(u => u.UserId == userId);
            }

            var subs = await query
                .ToListAsync();

            return subs.Select(Mapper.MapSub);
        }

        public async Task<bool> RemoveSubscriptionsAsync(int id)
        {
            Model.Subscriptions Subscriptions = await _context.Subscriptions.FindAsync(id);

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

        private static Core.Model.CoreSubscriptions MapSub(Model.Subscriptions subscriptions)
        {
            return subscriptions is null ? null : new Core.Model.CoreSubscriptions
            {
                Id = subscriptions.Id,
                SubscriptionDate = subscriptions.SubscriptionDate,
                SubscriptionDueDate = subscriptions.SubscriptionDueDate,
                Company = subscriptions.Company,
                Notification = subscriptions.Notification,
                SubscriptionMonthCost = subscriptions.SubscriptionMonthCost,
                SubscriptionName = subscriptions.SubscriptionName,
                UserId = subscriptions.UserId
                //User = MapUsers(subscriptions.User)
            };
        }
    }
}
