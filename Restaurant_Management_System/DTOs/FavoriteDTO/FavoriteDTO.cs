namespace Restaurant_Management_System.DTOs.FavoriteDTO
{
    public class FavoriteDTO
    {
        public int Id { get; set; }
        public string NameAR { get; set; }
        public string NameEN { get; set; }
        public string DescriptionAR { get; set; }
        public string DescriptionEN { get; set; }
        public decimal Price { get; set; }
        public string? CreationDate { get; set; }

    }
}
