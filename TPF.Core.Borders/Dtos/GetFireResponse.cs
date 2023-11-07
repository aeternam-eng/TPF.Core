#nullable disable

namespace TPF.Core.Borders.Dtos
{
    public record GetFireResponse
    {
        public bool IsFogoBixo { get; init; }
        public decimal Fogo { get; init; }
        public decimal Neutra { get; init; }
        public decimal Fumaça { get; init; }
        public decimal Humidity { get; init; }
        public decimal Temperature { get; init; }
        public decimal EnvironmentalFireProbability { get; init; }
    }
}
