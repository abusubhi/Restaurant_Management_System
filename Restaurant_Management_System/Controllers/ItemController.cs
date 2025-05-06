using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.DTOs.Items;
using Restaurant_Management_System.IService;
using Restaurant_Management_System.Models;
using Restaurant_Management_System.Service;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItem _RMSDbContext;
        public ItemController(IItem RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }

        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems([FromQuery] PaginationParameters pagination)
        {

            try
            {
                var result = await _RMSDbContext.GetAllItems(pagination);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetItemsByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetItemsByCategoryId([FromRoute] int categoryId)
        {

            try
            {
                var existing = await _RMSDbContext.GetItemsByCategoryId(categoryId);
                return existing is null ? NotFound() : Ok(existing);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetTopRatedItem")]
        public async Task<IActionResult> GetTopRatedItem()
        {

            try
            {
                var existing = await _RMSDbContext.GetTopRatedItems();
                return existing is null ? NotFound() : Ok(existing);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
