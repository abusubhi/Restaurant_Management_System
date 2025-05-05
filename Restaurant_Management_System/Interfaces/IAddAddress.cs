using Restaurant_Management_System.DTOs.AddressDTO;

namespace Restaurant_Management_System.Interfaces
{
    public interface IAddAddress
    {
        Task<string> AddAddressAsync(AddAddressDTO addAddressDTO);
    }
}
