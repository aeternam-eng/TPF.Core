#nullable disable

using Microsoft.AspNetCore.Http;

namespace TPF.Core.Borders.Entities
{
    public record MeasurementData
    {
        public IFormFile File { get; init; }
        public decimal Umi { get; init; }
        public decimal Temp { get; init; }
        public decimal Lon { get; init; }
        public decimal Lat { get; init; }
    }
}
