using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.DTOs.CartDTO;
using Restaurant_Management_System.IService;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _RMSDbContext;
        public CartController(ICart RMSDbContext)
        {
            _RMSDbContext = RMSDbContext;
        }

        [HttpPost]
        [Route("Add Item To Cart")]
        public async Task<IActionResult> AddItemToCart(CreateCartDTO input)
        {
            try
            {
                var result = await _RMSDbContext.AddItemToCart(input);
                return Ok(result);
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message;
                return BadRequest($"Error: {innerMessage}");
            }
        }


        [HttpGet]
        [Route("Get Current Cart by User Id")]
        public async Task<IActionResult> GetItemsFromCart(int UserId)
        {
            try
            {
                var result = await _RMSDbContext.GetItemsFromCart(UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete Item From Cart")]
        public async Task<IActionResult> DeleteItemFromCart(int ItemId, int UserId)
        {
            try
            {
                var result = await _RMSDbContext.DeleteItemFromCart(ItemId, UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete Cart")]
        public async Task<IActionResult> DeleteFromCart(int UserId)
        {
            try
            {
                var result = await _RMSDbContext.DeleteFromCart(UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
