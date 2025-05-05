using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteficationController : ControllerBase
    {
        private readonly INotification _notification;

        public VoteficationController(INotification inotification)
        {
            _notification = inotification;
        }


        [HttpPost("GetNotificationsForUser")]
        public async Task<IActionResult> GetNotificationsForUser(int userId)
        {
            try
            {
                if (userId > 0)
                {
                    var notifications = await _notification.GetNotificationsForUser(userId);
                    if (notifications == null || notifications.Count == 0)
                        return NotFound("No notifications found");
                    return Ok(notifications);
                }
                return NotFound("No notifications found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
