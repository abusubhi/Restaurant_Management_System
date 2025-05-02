namespace Restaurant_Management_System.DTOs.ItemsDTO.Request
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int OrderCount { get; set; }
    }
}
