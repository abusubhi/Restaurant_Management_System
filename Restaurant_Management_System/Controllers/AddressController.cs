using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.DTOs.AddressDTO;
using Restaurant_Management_System.Interfaces;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddAddress _addAddressService;
        public AddressController(IAddAddress addAddressService)
        {
            _addAddressService = addAddressService;
        }
        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddress([FromBody] AddAddressDTO addAddressDTO)
        {
            if (addAddressDTO == null)
            {
                return BadRequest("Invalid address data.");
            }
            var result = await _addAddressService.AddAddressAsync(addAddressDTO);
            return Ok(result);
        }
    }
}
