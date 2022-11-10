#nullable disable

namespace TPF.Core.Borders.Dtos
{
    public record GetFireResponse
    {
        public bool IsFogoBixo { get; init; }
        public decimal Probability { get; init; }
        public string ImageUrl { get; init; }
    }
}
