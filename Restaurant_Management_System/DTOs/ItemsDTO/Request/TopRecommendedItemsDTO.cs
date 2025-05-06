namespace Restaurant_Management_System.DTOs.ItemsDTO.Request
{
    public class TopRecommendedItemsDTO
    {
        public int Id { get; set; }
        public string NameAr { get; set; } = null!;

        public string NameEn { get; set; } = null!;

        public string? DescriptionAr { get; set; }

        public string? DescriptionEn { get; set; }

        public Decimal Price { get; set; }
        public string Image { get; set; }
    }
}
