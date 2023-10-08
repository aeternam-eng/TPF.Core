#nullable disable

namespace TPF.Core.Borders.Entities;

public record User
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Secret { get; init; }

    public Dtos.UserResponse ToUserResponse() =>
        new()
        {
            Id = Id,
            Name = Name,
            Email = Email
        };
}
