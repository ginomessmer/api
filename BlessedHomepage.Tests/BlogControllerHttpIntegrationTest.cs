using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlessedHomepage.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Xunit;

namespace BlessedHomepage.Tests
{
    public class BlogControllerHttpIntegrationTest
    {
        private IConfiguration Configuration { get; set; }

        private TestServer _server;
        private HttpClient _client;

        public BlogControllerHttpIntegrationTest()
        {
            // For testing purposes, I initialize my dependencies in here.
            // I recommend to use a test fixture instead though.

            // Set up local configuration
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<BlogControllerHttpIntegrationTest>(true)
                .AddEnvironmentVariables()
                .Build();

            // Set up web host
            var builder = new WebHostBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddJsonFile("Static/appsettings.json");
                })
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            // Set up test server
            _server = new TestServer(builder);
            _client = _server.CreateClient();

            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"Bearer {Configuration["Jwt"]}");
        }

        [Fact]
        public async Task Create_NewPost_Successfully()
        {
            var response = await _client.PostAsync("/blog/posts", new StringContent(JsonConvert.SerializeObject(new
            {
                id = "test-post",
                title = "This was literally posted from an integration test",
                externalLink = "http://example.com",
                postedAt = DateTime.Now
            })));

            response.EnsureSuccessStatusCode();
        }
    }
}
