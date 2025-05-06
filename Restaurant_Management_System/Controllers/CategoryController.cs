using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.IService;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategory _RMSDbContext;
        public CategoryController(ICategory RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllActiveCategories([FromQuery] PaginationParameters pagination)
        {

            try
            {
                var result = await _RMSDbContext.GetAllCategory(pagination);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }
    }
}
