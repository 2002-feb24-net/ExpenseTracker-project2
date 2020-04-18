using ExpenseService.Domain.Interrfaces;
using ExpenseService.Domain.Model;
using ExpenseService.ServiceeAccess.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExpenseService.ServiceeAccess.Repository
{
    public class ExpensesService : IExpensesService
    {
        //Private variables
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        //Constructor
        public ExpensesService(HttpClient httpClient, IOptionsMonitor<ExpenseServiceOption> optionsAccessor)
        {
            _httpClient = httpClient;

            // e.g. "https://localhost:44308/" in appsettings.Development.json (used by VS or dotnet CLI)
            // e.g. "https://adsf.azurewebsites.com/" in configuration on the App Service
            //     (set using environment variable named NotesService__ServiceBaseUrl)
            _httpClient.BaseAddress = new Uri(optionsAccessor.CurrentValue.ServiceBaseUrl);
            _httpClient.DefaultRequestHeaders.Add("Accept", MediaTypeNames.Application.Json);
        }



        public async Task AddBillAsnyc(Bills bills)
        {
            string content = JsonSerializer.Serialize(bills);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/bills")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task AddBugetAsync(Budgets budgets)
        {
            string content = JsonSerializer.Serialize(budgets);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/budgets")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task AddLaonsAsync(Loan loan)
        {
            string content = JsonSerializer.Serialize(loan);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/loan")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task AddLoanApplication(LoanApplication application)
        {
            string content = JsonSerializer.Serialize(application);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/application")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        //Add customer Async
        public async Task AddUserAsync(Users user)
        {
            // sometimes we want more control over exactly what e.g. headers we send with the request.
            // in that case, don't use GetAsync, PostAsync, etc.
            // instead, build a HttpRequestMessage ahead of time, and send it with SendAsync

            string content = JsonSerializer.Serialize(user);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/users")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteApplication(LoanApplication application)
        {
            string content = JsonSerializer.Serialize(application);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/application")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json),
                Method = HttpMethod.Delete
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBillsAsync(Bills bills)
        {
            string content = JsonSerializer.Serialize(bills);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/bills")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json),
                Method = HttpMethod.Delete
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBudgetAsync(Budgets budgets)
        {
            string content = JsonSerializer.Serialize(budgets);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/budgets")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json),
                Method = HttpMethod.Delete
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteLoan(Loan loan)
        {
            string content = JsonSerializer.Serialize(loan);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/loan")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json),
                Method = HttpMethod.Delete
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        //Delete user
        public async Task DeleteUseer(Users user)
        {
            string content = JsonSerializer.Serialize(user);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/users")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json),
                //HttpMethod to delete
                Method = HttpMethod.Delete

                //Add possible URI
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<LoanApplication>> GetApplications()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/application");

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            using Stream contentStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<LoanApplication>>(contentStream, _jsonSerializerOptions);
        }

        public async Task<IEnumerable<Budgets>> GetBudgetsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/budgets");

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            using Stream contentStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Budgets>>(contentStream, _jsonSerializerOptions);
        }

        public async Task<IEnumerable<Loan>> GetLoansAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/loan");

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            using Stream contentStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Loan>>(contentStream, _jsonSerializerOptions);
        }

        public async Task<IEnumerable<Bills>> GettBillsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/bills");

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            using Stream contentStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Bills>>(contentStream, _jsonSerializerOptions);
        }

        //Get all users
        public async Task<IEnumerable<Users>> GetUsersASync()
        {
            // this line would throw if we can't connect or we can't get the response headers
            //HttpResponseMessage response = await _httpClient.GetAsync("api/notes");

            var request = new HttpRequestMessage(HttpMethod.Get, "api/users");

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            // this line will throw if the status code is not a success code
            // i should catch this exception in the controller and return 502
            // ... but 500 is fine too, that's what will happen if we don't catch it
            response.EnsureSuccessStatusCode();

            // but we haven't downloaded the whole response body yet
            // while downloading the response body, parse it as JSON into an IEnumerable<Note>
            using Stream contentStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Users>>(contentStream, _jsonSerializerOptions);
        }
    }
}
