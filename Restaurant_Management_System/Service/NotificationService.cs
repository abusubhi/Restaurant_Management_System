


﻿using Restaurant_Management_System.DTOs.NotificationsDTO.Response;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Service
{
    public class NotificationService : INotification
    {
            private readonly RMSDbContext _rMSDbContext;
            public NotificationService(RMSDbContext rMSDbContext)
                   {
                        _rMSDbContext = rMSDbContext;
                   }
        public async Task<List<NotificationsDTO>> GetNotificationsForUser(int userId)
        {
            var not = _rMSDbContext.Notifications
                .Where(n => n.UserId == userId)
                .Select(n => new NotificationsDTO
                {
                    Id = n.NotificationId,
                    Title = n.Title,
                    Content = n.Content,
                    CreatedAt = n.CreationDate.ToString(),
                    IsRead = n.IsRead ?? false
                })
                .ToList();
            return not;
        }
}
    
}
