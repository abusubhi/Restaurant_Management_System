using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase 
    {
        private readonly IItem _iItem;
        private readonly RMSDbContext _rMSDbContext;
        private readonly INotification _notification;

        public ItemsController(RMSDbContext rMSDbContext , IItem iItem , INotification inotification)
        {
            _rMSDbContext = rMSDbContext;
            _iItem = iItem;
            _notification = inotification;
        }

        [HttpPost("GetItemById")]
        public async Task<IActionResult> GetItemById(int itemId)
        {
            try
            {
                if(itemId >0 )
                {

               
                var item = await _iItem.GetItemById(itemId);
                if (item == null)
                    return NotFound("Item not found");
                return Ok(item);
            }
                return NotFound("No Item found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            } 
        }

        [HttpGet("GetTopTenItems")]
        public async Task<IActionResult> GetTopTenItems()
        {
            try
            {
                var items = await _iItem.GetTopTenItems();
                if (items == null || items.Count == 0)
                    return NotFound("No items found");
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetNotificationsForUser")]
        public async Task<IActionResult> GetNotificationsForUser(int userId)
        {
            try
            {
                if(userId > 0) { 
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
