namespace Restaurant_Management_System.DTOs.ItemsDTO.Request
{
    public class ItemDetailsDTO
    {
        public int Id { get; set; }
        public string NameAr { get; set; } = null!;

        public string NameEn { get; set; } = null!;

        public string? DescriptionAr { get; set; }

        public string? DescriptionEn { get; set; }

        public float Price { get; set; }
        public decimal? Rate { get; set; }
        public int NumberOfRevew { get; set; }
    }
}
