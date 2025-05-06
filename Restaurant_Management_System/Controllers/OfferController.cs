using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.DTOs;
using Restaurant_Management_System.IService;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOffers _RMSDbContext;
        public OfferController(IOffers RMSDbContext)
        {


            _RMSDbContext = RMSDbContext;
        }

        [HttpGet]
        [Route("Get All Offers")]

        public async Task<IActionResult> GetAllOffers([FromQuery] PaginationParameters pagination)
        {
            try
            {
                return Ok(await _RMSDbContext.GetAllOffers(pagination));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
