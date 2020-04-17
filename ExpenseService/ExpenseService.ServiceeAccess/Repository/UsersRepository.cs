using ExpenseService.ServiceeAccess.Interrfaces;
using ExpenseService.ServiceeAccess.Options;
using ExpenseServiceAPI.Models;
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
    class UsersRepository : IUserRepository
    {
        //Private variables
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        //Constructor
        public UsersRepository(HttpClient httpClient, IOptionsMonitor<UsersServiceOptions> optionsAccessor)
        {
            _httpClient = httpClient;

            // e.g. "https://localhost:44308/" in appsettings.Development.json (used by VS or dotnet CLI)
            // e.g. "https://adsf.azurewebsites.com/" in configuration on the App Service
            //     (set using environment variable named NotesService__ServiceBaseUrl)
            _httpClient.BaseAddress = new Uri(optionsAccessor.CurrentValue.ServiceBaseUrl);
            _httpClient.DefaultRequestHeaders.Add("Accept", MediaTypeNames.Application.Json);
        }

        //Add customer Async
        public async Task AddUserAsync(Users user)
        {
            // sometimes we want more control over exactly what e.g. headers we send with the request.
            // in that case, don't use GetAsync, PostAsync, etc.
            // instead, build a HttpRequestMessage ahead of time, and send it with SendAsync

            string content = JsonSerializer.Serialize(user);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/notes")
            {
                Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public Task DeleteUseer(Users users)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Users>> GetUsersASync()
        {
            // this line would throw if we can't connect or we can't get the response headers
            //HttpResponseMessage response = await _httpClient.GetAsync("api/notes");

            var request = new HttpRequestMessage(HttpMethod.Get, "api/notes");

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
