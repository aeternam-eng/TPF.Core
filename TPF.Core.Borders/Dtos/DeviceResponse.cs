namespace TPF.Core.Borders.Dtos;

public record DeviceResponse
{
    public Guid Id { get; init; }
    public Guid User_Id { get; init; }
    public decimal Latitude { get; init; }
    public decimal Longitude { get; init; }
    public string Name { get; init; } = string.Empty;
    public List<FireDto> Fires { get; set; } = new();
}
