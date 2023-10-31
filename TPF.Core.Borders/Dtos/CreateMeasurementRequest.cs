#nullable disable

using Microsoft.AspNetCore.Http;

namespace TPF.Core.Borders.Dtos;

public record CreateMeasurementRequest
{
    public IFormFile Img { get; init; }
    public Guid DeviceId { get; init; }
    public decimal Temperature { get; init; }
    public decimal Humidity { get; init; }
}
