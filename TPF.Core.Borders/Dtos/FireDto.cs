namespace TPF.Core.Borders.Dtos;

public record FireDto
{
    public Guid Id { get; init; }
    public bool Is_fogo_bicho { get; init; }
    public decimal Environmental_fire_probability { get; init; }
    public DateTime Date_time { get; init; }
    public decimal Temperature { get; init; }
    public decimal Humidity { get; init; }
    public decimal Fire { get; init; }
    public decimal Smoke { get; init; }
}
