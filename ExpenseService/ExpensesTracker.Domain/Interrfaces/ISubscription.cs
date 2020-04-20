﻿using ExpenseService.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Interrfaces
{
    public interface ISubscription
    {
        Task<IEnumerable<Subscriptions>> GetSubscriptionssAsync(int? userId = null);
        Task<Subscriptions> GetSubscriptionsByIdAsync(int id);
        Task<bool> SubscriptionsExsistsAsync(int id);
        Task<Subscriptions> AddSubscriptionsAsync(Subscriptions Subscriptions);
        Task<bool> RemoveSubscriptionsAsync(int id);
        public EntityState Changed(Subscriptions Subscriptions);

        Task SaveAsync();
    }
}
