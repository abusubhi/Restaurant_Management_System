using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.DTOs.PaymentCardDTO;
using Restaurant_Management_System.Interfaces;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCardController : ControllerBase
    {
        private readonly IPaymentCard _addPaymentCardService;
        public PaymentCardController(IPaymentCard addPaymentCardService)
        {
            _addPaymentCardService = addPaymentCardService;
        }
        [HttpPost("AddPaymentCard")]
        public async Task<IActionResult> AddPaymentCard([FromBody] AddPaymentCardDTO addPaymentCardDTO)
        {
            if (addPaymentCardDTO == null)
                return BadRequest("Payment card details cannot be null");
            var result = await _addPaymentCardService.AddPaymentCard(addPaymentCardDTO);
            return Ok(result);
        }
    }
}
