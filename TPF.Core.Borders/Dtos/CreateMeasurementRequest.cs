#nullable disable

using Microsoft.AspNetCore.Http;
using TPF.Core.Borders.Entities;

namespace TPF.Core.Borders.Dtos
{
    public record CreateMeasurementRequest
    {
        public IFormFile Img { get; init; }
        public Guid DeviceId { get; init; }
        public decimal Humidity { get; init; }
        public decimal Temperature { get; init; }

        public MeasurementData ToModel(decimal latitude, decimal longitude) => new()
        {
            File = Img,
            Umi = Humidity,
            Temp = Temperature,
            Lat = latitude,
            Lon = longitude
        };
    }
}
