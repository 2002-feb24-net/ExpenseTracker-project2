using ExpenseService.ServiceeAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ExpensesTracker.Infrastructure
{
    public class UsersDbIntizied : DropCreateDatabaseIfModelChanges<RevatureDatabaseContext>
    {
        protected override void Seed(RevatureDatabaseContext context)
        {
            base.Seed(context);
        }
    }
}
