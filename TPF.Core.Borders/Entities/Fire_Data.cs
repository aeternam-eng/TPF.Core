namespace TPF.Core.Borders.Entities
{
    public record Fire_Data
    {
        public Guid Id { get; set; }
        public Guid Device_Id { get; set; }
        public bool Is_fogo_bicho { get; set; }
        public decimal Image_Fire_Probability { get; set; }
        public DateTime Date { get; set; }
    }
}
