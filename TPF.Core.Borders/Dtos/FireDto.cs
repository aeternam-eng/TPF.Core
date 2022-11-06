namespace TPF.Core.Borders.Dtos;

public class FireDto
{
    public Guid Id { get; init; }
    public DeviceResponse Device { get; init; } = default!;
    public bool Is_fogo_bicho { get; init; }
    public decimal Image_Fire_Probability { get; init; }
    public DateTime Date { get; init; }
}
