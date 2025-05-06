using Restaurant_Management_System.DTOs.NotificationsDTO.Response;

namespace Restaurant_Management_System.IService
{
    public interface INotification
    {
         Task<List<NotificationsDTO>> GetNotificationsForUser(int userId);
    }
}
