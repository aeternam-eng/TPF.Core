using System.Text;
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

    public FireRepository(ApplicationConfig applicationConfig)
    {
        _applicationConfig = applicationConfig;
    }

    public async Task<GetFireResponse> AnalyzeImage(MeasurementData data)
    {
        var obj = new
        {
            data.Lon,
            data.Lat,
            data.Temp,
            data.Umi,
            data.File
        };

        var httpContent = new StringContent(JsonConvert.SerializeObject(obj, new JsonSerializerSettings()), Encoding.UTF8, "application/json");

        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(_applicationConfig.Endpoint.ApiIa),
        };

        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        var response = await httpClient.PostAsync("/api/analysis", httpContent);

        var result = response.Content;
        var dataStream = result.ReadAsStream();
        var reader = new StreamReader(dataStream);
        var objResponse = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<GetFireResponse>(objResponse.ToString());
    }
}
