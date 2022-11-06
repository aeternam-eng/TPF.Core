public record UpdateDeviceNameRequest
{
    public Guid DeviceId { get; init; } = Guid.NewGuid();
    public string NewName { get; init; } = string.Empty;
}
