using TPF.Core.Borders.Entities;

namespace TPF.Core.Borders.Dtos;

public record CreateUserRequest
{
    public string Name { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public User ToModel() => new() { Name = Name, Secret = Secret, Email = Email };
}