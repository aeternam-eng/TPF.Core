namespace TPF.Core.Borders.Entities
{
    public record Device
    {
        public Guid Id { get; init; }
        public Guid User_Id { get; init; }
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
