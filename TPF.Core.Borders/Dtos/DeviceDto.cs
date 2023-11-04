namespace TPF.Core.Borders.Dtos;

public class DeviceDto
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public decimal Latitude { get; init; }
    public decimal Longitude { get; init; }
    public string Name { get; init; } = string.Empty;
    public bool IsFire { get; init; }
    public MeasurementDto LastMeasurement { get; init; } = new();
    public IEnumerable<FireDto> Fires { get; init; } = new List<FireDto>();
}
