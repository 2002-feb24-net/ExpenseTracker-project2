using ExpenseService.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseService.Core.Interrfaces
{
    public interface ISubscription
    {
        Task<IEnumerable<CoreSubscriptions>> GetSubscriptionssAsync(int? userId = null);
        Task<CoreSubscriptions> GetSubscriptionsByIdAsync(int id);
        Task<bool> SubscriptionsExsistsAsync(int id);
        Task<CoreSubscriptions> AddSubscriptionsAsync(CoreSubscriptions Subscriptions);
        Task<bool> RemoveSubscriptionsAsync(int id);
        public EntityState Changed(CoreSubscriptions Subscriptions);

        Task SaveAsync();
    }
}
