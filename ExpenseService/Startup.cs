using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseService.Core.Interrfaces;
using ExpenseService.DataAccess.Model;
using ExpenseService.DataAccess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExpenseService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddScoped<IBillsRepository, Billrepository>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IApplication, ApplicationRepository>();
            services.AddScoped<ISubscription, Subscription>();

            services.AddDbContext<RevatureDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Project2String")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
