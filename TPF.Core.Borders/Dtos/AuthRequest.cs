#nullable disable 

namespace TPF.Core.Borders.Dtos;

public record AuthRequest
{
    public string Email { get; init; }
    public string Password { get; init; }
}