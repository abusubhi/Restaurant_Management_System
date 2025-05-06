namespace Restaurant_Management_System.DTOs.ItemsDTO.Request
{
    public class TopRatedItemDTO
    {
        public int Id { get; set; }
        public string NameAR { get; set; }
        public string NameEN { get; set; }
        public string DescriptionAR { get; set; }
        public string DescriptionEN { get; set; }
        public string? ItemImage { get; set; }
        public decimal Price { get; set; }
        public decimal? ItemRate { get; set; }
    }

}
