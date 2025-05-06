namespace Restaurant_Management_System.DTOs.ItemsDTO.Request
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string NameAr { get; set; } = null!;

        public string NameEn { get; set; } = null!;

        public string? DescriptionAr { get; set; }

        public string? DescriptionEn { get; set; }

        public float Price { get; set; }
        public string Image { get; set; }
        public int OrderCount { get; set; }
        public decimal? Rate { get; set; }
        public int RateId { get; set; }
    }
}
