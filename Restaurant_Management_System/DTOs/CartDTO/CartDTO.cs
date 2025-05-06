namespace Restaurant_Management_System.DTOs.CartDTO
{
    public class CartDTO
    {
        public int ItemId { get; set; }
        public string NameAr { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string? DescriptionAr { get; set; }
        public string? DescriptionEn { get; set; }
        public int Quantity { get; set; }
    }
}
