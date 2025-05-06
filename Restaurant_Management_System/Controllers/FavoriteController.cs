using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.DTOs.FavoriteDTO;
using Restaurant_Management_System.IService;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavorite _RMSDbContext;
        public FavoriteController(IFavorite RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }

        [HttpGet]
        [Route("Get Favorite List")]
        public async Task<IActionResult> GetFavoritebyUserId(int userId)
        {
            try
            {
                var result = await _RMSDbContext.GetFavoritebyUserId(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete]
        [Route("Delete Item From Favorite")]
        public async Task<IActionResult> DeleteItemFromFavorite(int ItemId, int UserId)
        {
            try
            {
                var result = await _RMSDbContext.DeleteItemFromFavorite(ItemId, UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Add Item To Favorite")]
        public async Task<IActionResult> AddItemToFavorite(int ItemId, int UserId)
        {
            try
            {
                var result = await _RMSDbContext.AddItemToFavorite(ItemId, UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
