using eBookRental.Api;
using eBookRental.Infrastructure.Commands.Users;
using eBookRental.Infrastructure.DTO;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace eBookRental.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UsersControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                             .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "ania@domain.com";
            var response = await _client.GetAsync($"users/{email}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            user.Email.ShouldBeEquivalentTo(email);
        }

        [Fact]
        public async Task given_invalid_email_user_should_not_exist()
        {
            var email = "invalid_user@domain.com";
            var response = await _client.GetAsync($"users/{email}");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new CreateUser
            {
                Username = "testUser",
                FullName = "test User",
                Email = "test@email.com",
                Password = "test",
                Role = "testRole"
             };

            var payload = GetPayload(request);
            var response = await _client.PostAsync($"users", payload);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{request.Email}");
        }

        //W zapytaniu przekazujemy Http/StringContent. Tak tworzymy stringa, który bedzie się serializował do postaci json'a
        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
