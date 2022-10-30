namespace TPF.Core.Borders.Entities
{
    public record Device
    {
        public Guid Id { get; set; }
        public Guid User_Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
