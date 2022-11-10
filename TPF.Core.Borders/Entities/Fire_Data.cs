namespace TPF.Core.Borders.Entities
{
    public record Fire_Data
    {
        public Guid Id { get; init; }
        public Guid Device_Id { get; init; }
        public bool Is_Fogo_Bixo { get; init; }
        public decimal Image_Fire_Probability { get; init; }
        public DateTime Date_Time { get; init; }
        public string? Image_Url { get; init; } = null;
    }
}
