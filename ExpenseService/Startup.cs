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
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

[assembly: ApiController]
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
            services.AddApplicationInsightsTelemetry();
            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddScoped<IBillsRepository, Billrepository>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IApplication, ApplicationRepository>();
            services.AddScoped<ISubscription, Subscription>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Client API", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalAndAppServiceAngular", builder =>
                    builder.WithOrigins("https://revatureexpensetracker-client.azurewebsites.net", "http://revatureexpensetracker-client.azurewebsites.net",
                                        "http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
                options.ReturnHttpNotAcceptable = true;
                options.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddDbContext<RevatureDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Project2String")));
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowLocalAndAppServiceAngular");

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
