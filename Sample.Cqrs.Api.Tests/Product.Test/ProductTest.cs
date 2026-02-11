using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Sample.Cqrs.Domain.Common;

namespace Sample.Cqrs.Api.Tests.Product.Test
{
    public class ProductTest : IClassFixture<TestWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ProductTest(TestWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateProduct_ShouldReturnCreated()
        {
            // Arrange
            var request = new
            {
                name = "Integration Product",
                description = "Test product",
                imageUrl = "img.jpg",
                price = 25,
                stockQuantity = 10
            };

            var token = await LoginAsync();

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.PostAsJsonAsync(
                "/api/product",
                request);

            // Assert

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var body = await response.Content.ReadFromJsonAsync<dynamic>();

            Assert.NotNull(body);
        }

        private async Task<string> LoginAsync()
        {
            var loginRequest = new
            {
                email = "admin@demo.com",
                password = "Admin123!"
            };

            var response = await _client.PostAsJsonAsync(
                "/api/auth/login",
                loginRequest);

            response.EnsureSuccessStatusCode();

            var body = await response.Content
                .ReadFromJsonAsync<BaseResponse<string>>();

            return body!.Result ?? "";
        }

    }
}
