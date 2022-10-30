namespace TPF.Core.Shared.Configurations;

#nullable disable

public record ApplicationConfig
{
    public ConnectionStrings ConnectionStrings { get; init; }
    public AuthenticationConfiguration Authentication { get; init; }
    public Endpoint Endpoint { get; set; }
}

public record ConnectionStrings
{
    public string DefaultConnection { get; init; }
}

public record AuthenticationConfiguration
{
    public string Secret { get; init; }
}

public record Endpoint
{
    public string ApiIa { get; init; }
}