using Restaurant_Management_System.DTOs.NotificationsDTO.Response;

namespace Restaurant_Management_System.IService
{
    public interface INotification
    {
        public Task<List<NotificationsDTO>> GetNotificationsForUser(int userId);
    }
}
