using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Shared.Configurations;

#nullable disable

namespace TPF.Core.Repositories
{
    public class FireRepository : IFireRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationConfig _applicationConfig;

        public FireRepository(ApplicationConfig applicationConfig, HttpClient httpClient)
        {
            _applicationConfig = applicationConfig;
            _httpClient = httpClient;
        }

        public async Task<GetFireResponse> GetFire(IFormFile img)
        {
            var uri = $"{_applicationConfig.Endpoint.ApiIa}";

            using var stream = img.OpenReadStream();
            using var content = new MultipartFormDataContent
            {
                { new StreamContent(stream), "file", "img.jpg" }
            };

            using var httpResponse = await _httpClient.PostAsync(uri, content);
            var responseBody = await httpResponse.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GetFireResponse>(responseBody);
        }
    }
}
