namespace Restaurant_Management_System.DTOs.NotificationsDTO.Response
{
    public class NotificationsDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string? NotificationType { get; set; }
        public string CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }
}
