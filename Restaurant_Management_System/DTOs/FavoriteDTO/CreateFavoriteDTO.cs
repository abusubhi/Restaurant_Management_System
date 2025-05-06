using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.DTOs.FavoriteDTO
{
    public class CreateFavoriteDTO
    {
        public int? UserId { get; set; }

        public int? ItemId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Item? Item { get; set; }

        public virtual User? User { get; set; }
    }
}
