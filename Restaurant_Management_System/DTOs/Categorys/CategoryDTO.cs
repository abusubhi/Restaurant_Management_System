

namespace Restaurant_Management_System.DTOs.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string NameEn { get; set; }

        public string NameAr { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
