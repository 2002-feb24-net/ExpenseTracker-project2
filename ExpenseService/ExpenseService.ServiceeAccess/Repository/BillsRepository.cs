using ExpenseService.ServiceeAccess.Interrfaces;
using ExpenseService.ServiceeAccess.Models;
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
    public class BillsRepository : IBillsRepsitory
    {
        //Private variables for bills
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };


        public BillsRepository(HttpClient httpClient, IOptionsMonitor<ExpenseServiceOption> optionsAccessor)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(optionsAccessor.CurrentValue.ServiceBaseUrl);
            _httpClient.DefaultRequestHeaders.Add("Accept", MediaTypeNames.Application.Json);
        }

        public async Task AddBillsAsync(Bills bills)
        {
            string content = JsonSerializer.Serialize(bills);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/bills")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBills(Bills bills)
        {
            string content = JsonSerializer.Serialize(bills);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/bills")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json),
                //HttpMethod to delete
                Method = HttpMethod.Delete

                //Add possible URI
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Bills>> GetBillsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/users");

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            using Stream contentStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Bills>>(contentStream, _jsonSerializerOptions);
        }
    }
}
