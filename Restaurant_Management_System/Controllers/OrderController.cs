using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.Interfaces;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Service;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _RMSDbContext;
        public OrderController(IOrder RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }

        [HttpGet("order-history/{userId}")]
        public async Task<IActionResult> GetOrderHistoryByUserId(int userId, [FromQuery] PaginationParameters pagination)
        {
            var history = await _RMSDbContext.GetOrderHistoryByUserId(userId, pagination);

            if (history == null || !history.Any())
            {
                return NotFound("No order history found for this user.");
            }

            return Ok(history);
        }
    }
}
