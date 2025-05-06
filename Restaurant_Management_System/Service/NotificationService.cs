using Restaurant_Management_System.DTOs.NotificationsDTO.Response;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Service
{
    public class NotificationService : INotification
    {
        private readonly RMSDbContext _RMSDbContext;
        public NotificationService(RMSDbContext RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }
        public async Task<List<NotificationsDTO>> GetNotificationsForUser(int userId)
        {
            var not = _RMSDbContext.Notifications
                .Where(n => n.UserId == userId)
                .Select(n => new NotificationsDTO
                {
                    Id = n.NotificationId,
                    NotificationType = n.NotificationType,
                    Content = n.Title,
                    CreatedAt = n.CreationDate.ToString(),
                    IsRead = n.IsRead ?? false
                })
                .ToList();
            return not;
        }
}
    
}
