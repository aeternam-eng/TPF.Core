using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Entities;
using TPF.Core.Borders.Repositories;
using TPF.Core.Shared.Configurations;

#nullable disable

namespace TPF.Core.Repositories;

public class FireRepository : IFireRepository
{
    private readonly ApplicationConfig _applicationConfig;
    private readonly HttpClient _httpClient;

    public FireRepository(ApplicationConfig applicationConfig, HttpClient httpClient)
    {
        _applicationConfig = applicationConfig;
        _httpClient = httpClient;

    }

    public async Task<GetFireResponse> AnalyzeImage(MeasurementData data)
    {
        using var stream = data.File.OpenReadStream();
        using var content = new MultipartFormDataContent
        {
            { new StringContent(data.Lat.ToString()), "lat" },
            { new StringContent(data.Lon.ToString()), "lon" },
            { new StringContent(data.Temp.ToString()), "temp" },
            { new StringContent(data.Umi.ToString()), "umi" },
            { new StreamContent(stream), "file", "img.jpg" },
        };

        var uri = $"{_applicationConfig.Endpoint.ApiIa}";
        using var httpResponse = await _httpClient.PostAsync(uri, content);
        var responseBody = await httpResponse.Content.ReadAsStringAsync();

        return System.Text.Json.JsonSerializer.Deserialize<GetFireResponse>(responseBody, new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() }
        });
    }
}
