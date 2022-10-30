#nullable disable


namespace TPF.Core.Borders.Dtos;

public record AuthResponse
{
    public Guid UserId { get; init; }
    public string Token { get; init; }
}

